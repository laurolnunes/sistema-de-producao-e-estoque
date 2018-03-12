namespace SPE.Domain.Products.Commands.ProductItem
{
    public class DeleteProductItemCommand : BaseProductItemCommand
    {
        public DeleteProductItemCommand(int id)
        {
            Id = id;
            AggregateId = id;
        }
    }
}