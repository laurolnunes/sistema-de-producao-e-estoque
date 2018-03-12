namespace SPE.Domain.Products.Events.Product
{
    public class DeletedProductEvent : BaseProductEvent
    {
        public DeletedProductEvent(int id)
        {
            Id = id;
            AggregateId = id;
        }
    }
}