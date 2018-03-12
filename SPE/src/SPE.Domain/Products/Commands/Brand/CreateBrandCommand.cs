namespace SPE.Domain.Products.Commands.Brand
{
    public class CreateBrandCommand : BaseBrandCommand
    {
        public CreateBrandCommand(string name)
        {
            Name = name;
        }
    }
}