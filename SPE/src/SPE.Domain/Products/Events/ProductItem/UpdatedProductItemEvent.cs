namespace SPE.Domain.Products.Events.ProductItem
{
    public class UpdatedProductItemEvent : BaseProductItemEvent
    {
        public UpdatedProductItemEvent(int id, int productId, int productItemId, int units)
        {
            Id = id;
            ProductId = productId;
            ProductItemId = productItemId;
            Units = units;
            AggregateId = id;
        }
    }
}