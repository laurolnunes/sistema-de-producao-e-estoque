namespace SPE.Domain.Products.Events.Stock
{
    public class DeletedStockEvent : BaseStockEvent
    {
        public DeletedStockEvent(int id)
        {
            Id = id;
            AggregateId = id;
        }
    }
}