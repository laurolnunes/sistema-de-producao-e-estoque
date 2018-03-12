using SPE.Domain.CommandsHandlers;
using SPE.Domain.Core.Bus;
using SPE.Domain.Core.Events;
using SPE.Domain.Core.Notifications;
using SPE.Domain.Products.Events.Stock;
using SPE.Domain.Products.Repository;

namespace SPE.Domain.Products.Commands.Stock
{
    public class StockCommandHandler : CommandHandler, IHandler<CreateStockCommand>, IHandler<UpdateStockCommand>, IHandler<DeleteStockCommand>
    {
        private readonly IProductRepository _productRepository;
        private readonly IBus _bus;

        public StockCommandHandler(IProductRepository productRepository, 
                                   IUnitOfWork unitOfWork, 
                                   IBus bus, 
                                   IDomainNotificationHandler<DomainNotification> notifications) : base(unitOfWork, bus, notifications)
        {
            _productRepository = productRepository;
            _bus = bus;
        }

        public void Handle(CreateStockCommand message)
        {
            var stock = new Products.Stock(message.ProductId, message.BrandId, message.Units);
            if (!ValidStock(stock)) return;

            _productRepository.AddStock(stock);

            if (Commit())
            {
                _bus.RaiseEvent(new CreatedStockEvent(stock.Id, stock.ProductId, stock.BrandId, stock.Units,stock.UseBy));
            }
        }

        public void Handle(UpdateStockCommand message)
        {
            if (!StockExists(message.Id, message.MessageType)) return;

            var stock = Products.Stock.StockFactory.CompleteStock(message.Id, message.ProductId, message.BrandId, message.Units, message.UseBy);
            if(!ValidStock(stock)) return;

            _productRepository.UpdateStock(stock);

            if (Commit())
            {
                _bus.RaiseEvent(new UpdatedStockEvent(stock.Id, stock.ProductId, stock.BrandId, stock.Units, stock.UseBy));
            }
        }

        public void Handle(DeleteStockCommand message)
        {
            if (!StockExists(message.Id, message.MessageType)) return;

            _productRepository.RemoveStock(message.Id);
            
            if (Commit())
            {
                _bus.RaiseEvent(new DeletedStockEvent(message.Id));
            }
        }

        private bool ValidStock(Products.Stock stock)
        {
            if (stock.IsValid()) return true;

            NotifyErrorValidations(stock.ValidationResult);
            return false;
        }

        private bool StockExists(int id, string messageType)
        {
            var stock = _productRepository.GetStockById(id);
            if (stock != null) return true;

            _bus.RaiseEvent(new DomainNotification(messageType, "Stock not found."));
            return false;
        }
    }
}