using SPE.Domain.Core.Events;

namespace SPE.Domain.Products.Events.Brand
{
    public class BaseBrandEvent : Event
    {
        public int Id { get; set; }

        public string Name { get; set; }
    }
}