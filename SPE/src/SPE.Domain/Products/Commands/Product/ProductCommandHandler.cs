using SPE.Domain.CommandsHandlers;
using SPE.Domain.Core.Bus;
using SPE.Domain.Core.Events;
using SPE.Domain.Core.Notifications;
using SPE.Domain.Products.Events;
using SPE.Domain.Products.Events.Product;
using SPE.Domain.Products.Repository;

namespace SPE.Domain.Products.Commands.Product
{
    public class ProductCommandHandler : 
        CommandHandler, 
        IHandler<CreateProductCommand>, 
        IHandler<UpdateProductCommand>, 
        IHandler<DeleteProductCommand>
    {
        private readonly IProductRepository _productRepository;
        private readonly IBus _bus;

        public ProductCommandHandler(IProductRepository productRepository,
                                     IUnitOfWork unitOfWork,
                                     IBus bus,
                                     IDomainNotificationHandler<DomainNotification> notifications) : base(unitOfWork, bus, notifications)
        {
            _productRepository = productRepository;
            _bus = bus;
        }

        public void Handle(CreateProductCommand message)
        {
            var product = new Products.Product(message.Name, message.Description);
            if(!ValidProduct(product)) return;

            // Criar demais validações de negócio

            _productRepository.Add(product);

            if (Commit())
            {
                _bus.RaiseEvent(new CreatedProductEvent(product.Id, product.Name, product.Description));
            }
        }

        public void Handle(UpdateProductCommand message)
        {
            if (!ProductExists(message.Id, message.MessageType)) return;

            var product = Products.Product.ProductFactory.CompleteProduct(message.Id, message.Name, message.Description);
            if(!ValidProduct(product)) return;

            _productRepository.Update(product);

            if (Commit())
            {
                _bus.RaiseEvent(new UpdatedProductEvent(product.Id, product.Name, product.Description));
            }
        }

        public void Handle(DeleteProductCommand message)
        {
            if (!ProductExists(message.Id, message.MessageType)) return;

            _productRepository.Remove(message.Id);
            
            if (Commit())
            {
                _bus.RaiseEvent(new DeletedProductEvent(message.Id));
            }
        }

        private bool ValidProduct(Products.Product product)
        {
            if (product.IsValid()) return true;

            NotifyErrorValidations(product.ValidationResult);
            return false;
        }

        private bool ProductExists(int id, string messageType)
        {
            var product = _productRepository.GetById(id);
            if (product != null) return true;

            _bus.RaiseEvent(new DomainNotification(messageType, "Product not found."));
            return false;
        }
    }
}