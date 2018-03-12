using System;

namespace SPE.Domain.Products.Events.Stock
{
    public class CreatedStockEvent : BaseStockEvent
    {
        public CreatedStockEvent(int id, int productId, int brandId, int units, DateTime useBy)
        {
            Id = id;
            ProductId = productId;
            BrandId = brandId;
            Units = units;
            UseBy = useBy;
            AggregateId = id;
        }
    }
}