using SPE.Domain.Core.Events;

namespace SPE.Domain.Products.Events.Product
{
    public abstract class BaseProductEvent : Event
    {
        public int Id { get; protected set; }

        public string Name { get; protected set; }

        public string Description { get; protected set; }
    }
}