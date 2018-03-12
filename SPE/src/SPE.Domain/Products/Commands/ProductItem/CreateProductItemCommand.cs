namespace SPE.Domain.Products.Commands.ProductItem
{
    public class CreateProductItemCommand : BaseProductItemCommand
    {
        public CreateProductItemCommand(int productId, int productItemId, int units)
        {
            ProductId = productId;
            ProductItemId = productItemId;
            Units = units;
        }
    }
}