using SPE.Domain.Core.Commands;

namespace SPE.Domain.Products.Commands.Brand
{
    public class BaseBrandCommand : Command
    {
        public int Id { get; set; }

        public string Name { get; set; }
    }
}