using System;

namespace SPE.Domain.Products.Events.Stock
{
    public class UpdatedStockEvent : BaseStockEvent
    {
        public UpdatedStockEvent(int id, int productId, int brandId, int units, DateTime useBy)
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