namespace SPE.Domain.Products.Commands.ProductItem
{
    public class UpdateProductItemCommand : BaseProductItemCommand
    {
        public UpdateProductItemCommand(int id, int productId, int productItemId, int units)
        {
            Id = id;
            ProductId = productId;
            ProductItemId = productItemId;
            Units = units;
        }
    }
}