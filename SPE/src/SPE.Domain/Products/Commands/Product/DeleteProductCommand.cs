namespace SPE.Domain.Products.Commands.Product
{
    public class DeleteProductCommand : BaseProductCommand
    {
        public DeleteProductCommand(int id)
        {
            Id = id;
            AggregateId = id;
        }
    }
}