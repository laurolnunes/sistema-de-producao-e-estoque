using SPE.Domain.CommandsHandlers;
using SPE.Domain.Core.Bus;
using SPE.Domain.Core.Events;
using SPE.Domain.Core.Notifications;
using SPE.Domain.Products.Events.Brand;
using SPE.Domain.Products.Repository;

namespace SPE.Domain.Products.Commands.Brand
{
    public class BrandCommandHandler :
        CommandHandler,
        IHandler<CreateBrandCommand>,
        IHandler<UpdateBrandCommand>,
        IHandler<DeleteBrandCommand>
    {
        private readonly IProductRepository _productRepository;
        private readonly IBus _bus;

        public BrandCommandHandler(IProductRepository productRepository, 
                                    IUnitOfWork unitOfWork, 
                                    IBus bus, 
                                    IDomainNotificationHandler<DomainNotification> notifications) : base(unitOfWork, bus, notifications)
        {
            _productRepository = productRepository;
            _bus = bus;
        }

        public void Handle(CreateBrandCommand message)
        {
            var brand = new Products.Brand(message.Name);
            if (!ValidBrand(brand)) return;

            _productRepository.AddBrand(brand);

            if (Commit())
            {
                _bus.RaiseEvent(new CreatedBrandEvent(brand.Id, brand.Name));
            }
        }

        public void Handle(UpdateBrandCommand message)
        {
            if(!BrandExists(message.Id, message.MessageType)) return;

            var brand = Products.Brand.BrandFactory.CompleteBrand(message.Id, message.Name);
            if (!ValidBrand(brand)) return;

            _productRepository.AddBrand(brand);

            if (Commit())
            {
                _bus.RaiseEvent(new UpdatedBrandEvent(brand.Id, brand.Name));
            }
        }

        public void Handle(DeleteBrandCommand message)
        {
            if(!BrandExists(message.Id, message.MessageType)) return;

            _productRepository.RemoveBrand(message.Id);

            if (Commit())
            {
                _bus.RaiseEvent(new DeletedBrandEvent(message.Id));
            }
        }

        private bool ValidBrand(Products.Brand brand)
        {
            if (brand.IsValid()) return true;

            NotifyErrorValidations(brand.ValidationResult);
            return false;
        }

        private bool BrandExists(int id, string messageType)
        {
            var brand = _productRepository.GetBrandById(id);
            if (brand != null) return true;

            _bus.RaiseEvent(new DomainNotification(messageType, "Brand not found."));
            return false;
        }
    }
}