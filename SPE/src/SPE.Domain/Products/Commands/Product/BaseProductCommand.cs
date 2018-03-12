using SPE.Domain.Core.Commands;

namespace SPE.Domain.Products.Commands.Product
{
    public abstract class BaseProductCommand : Command
    {
        public int Id { get; protected set; }

        public string Name { get; protected set; }

        public string Description { get; protected set; }
    }
}