using SPE.Domain.Core.Events;

namespace SPE.Domain.Products.Events.Stock
{
    public class StockEventHandler :
        IHandler<CreatedStockEvent>,
        IHandler<UpdatedStockEvent>,
        IHandler<DeletedStockEvent>
    {
        public void Handle(CreatedStockEvent message)
        {
            // Enviar um e-mail ou fazer log
        }

        public void Handle(UpdatedStockEvent message)
        {
            // Enviar um e-mail ou fazer log
        }

        public void Handle(DeletedStockEvent message)
        {
            // Enviar um e-mail ou fazer log
        }
    }
}