namespace SPE.Domain.Products.Commands.Product
{
    public class UpdateProductCommand : BaseProductCommand
    {
        public UpdateProductCommand(int id, string name, string description)
        {
            Id = id;
            Name = name;
            Description = description;
        }
    }
}