using SPE.Domain.CommandsHandlers;
using SPE.Domain.Core.Bus;
using SPE.Domain.Core.Events;
using SPE.Domain.Core.Notifications;
using SPE.Domain.Products.Events.ProductItem;
using SPE.Domain.Products.Repository;

namespace SPE.Domain.Products.Commands.ProductItem
{
    public class ProductItemCommandHandler :
        CommandHandler,
        IHandler<CreateProductItemCommand>,
        IHandler<UpdateProductItemCommand>,
        IHandler<DeleteProductItemCommand>
    {
        private readonly IProductRepository _productRepository;
        private readonly IBus _bus;

        public ProductItemCommandHandler(IUnitOfWork unitOfWork, IBus bus, IDomainNotificationHandler<DomainNotification> notifications, IProductRepository productRepository) : base(unitOfWork, bus, notifications)
        {
            _productRepository = productRepository;
            _bus = bus;
        }

        public void Handle(CreateProductItemCommand message)
        {
            var productItem = new Products.ProductItem(message.ProductId, message.ProductItemId, message.Units);
            if(!ValidProductItem(productItem)) return;

            // Criar demais validações de negócio

            _productRepository.AddProductItem(productItem);

            if (Commit())
            {
                _bus.RaiseEvent(new CreatedProductItemEvent(productItem.Id, productItem.ProductId, productItem.ProductItemId, productItem.Units));
            }
        }

        public void Handle(UpdateProductItemCommand message)
        {
            if (!ProductItemExists(message.Id, message.MessageType)) return;

            var productItem = Products.ProductItem.ProductItemFactory.CompleteProductItem(message.Id, message.ProductId, message.ProductItemId, message.Units);
            if(!ValidProductItem(productItem)) return;

            _productRepository.UpdateProductItem(productItem);

            if (Commit())
            {
                _bus.RaiseEvent(new UpdatedProductItemEvent(productItem.Id, productItem.ProductId, productItem.ProductItemId, productItem.Units));
            }
        }

        public void Handle(DeleteProductItemCommand message)
        {
            if (!ProductItemExists(message.Id, message.MessageType)) return;

            _productRepository.Remove(message.Id);
            
            if (Commit())
            {
                _bus.RaiseEvent(new DeletedProductItemEvent(message.Id));
            }
        }

        private bool ValidProductItem(Products.ProductItem productItem)
        {
            if (productItem.IsValid()) return true;

            NotifyErrorValidations(productItem.ValidationResult);
            return false;
        }

        private bool ProductItemExists(int id, string messageType)
        {
            var productItem = _productRepository.GetById(id);
            if (productItem != null) return true;

            _bus.RaiseEvent(new DomainNotification(messageType, "Product Item not found."));
            return false;
        }
    }
}