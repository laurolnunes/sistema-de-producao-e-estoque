using SPE.Domain.Core.Events;

namespace SPE.Domain.Products.Events.ProductItem
{
    public class BaseProductItemEvent : Event
    {
        public int Id { get; set; }

        public int ProductId { get; set; }

        public int ProductItemId { get; set; }

        public int Units { get; set; }
    }
}