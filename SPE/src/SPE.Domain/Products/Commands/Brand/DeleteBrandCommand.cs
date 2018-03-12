namespace SPE.Domain.Products.Commands.Brand
{
    public class DeleteBrandCommand : BaseBrandCommand
    {
        public DeleteBrandCommand(int id)
        {
            Id = id;
            AggregateId = id;
        }
    }
}