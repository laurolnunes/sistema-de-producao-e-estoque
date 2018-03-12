namespace SPE.Domain.Products.Commands.Product
{
    public class CreateProductCommand : BaseProductCommand
    {
        public CreateProductCommand(string name, string description)
        {
            Name = name;
            Description = description;
        }
    }
}