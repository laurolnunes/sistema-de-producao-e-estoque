using System;
using SPE.Domain.Core.Events;

namespace SPE.Domain.Products.Events.Stock
{
    public class BaseStockEvent : Event
    {
        public int Id { get; set; }

        public int ProductId { get; set; }

        public int BrandId { get; set; }

        public int Units { get; set; }

        public DateTime UseBy { get; set; }
    }
}