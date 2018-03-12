namespace SPE.Domain.Products.Events.ProductItem
{
    public class DeletedProductItemEvent : BaseProductItemEvent
    {
        public DeletedProductItemEvent(int id)
        {
            Id = id;
            AggregateId = id;
        }
    }
}