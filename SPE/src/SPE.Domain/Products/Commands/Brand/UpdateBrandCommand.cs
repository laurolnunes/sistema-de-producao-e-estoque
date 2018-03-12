namespace SPE.Domain.Products.Commands.Brand
{
    public class UpdateBrandCommand : BaseBrandCommand
    {
        public UpdateBrandCommand(int id, string name)
        {
            Id = id;
            Name = name;
        }
    }
}