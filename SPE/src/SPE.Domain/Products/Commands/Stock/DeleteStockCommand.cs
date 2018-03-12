namespace SPE.Domain.Products.Commands.Stock
{
    public class DeleteStockCommand : BaseStockCommand
    {
        public DeleteStockCommand(int id)
        {
            Id = id;
            AggregateId = id;
        }
    }
}