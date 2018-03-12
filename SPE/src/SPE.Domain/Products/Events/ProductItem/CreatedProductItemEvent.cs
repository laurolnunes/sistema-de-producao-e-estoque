namespace SPE.Domain.Products.Events.ProductItem
{
    public class CreatedProductItemEvent : BaseProductItemEvent
    {
        public CreatedProductItemEvent(int id, int productId, int productItemId, int units)
        {
            Id = id;
            ProductId = productId;
            ProductItemId = productItemId;
            Units = units;
            AggregateId = id;
        }
    }
}