using System;

namespace SPE.Domain.Products.Commands.Stock
{
    public class UpdateStockCommand : BaseStockCommand
    {
        public UpdateStockCommand(int id, int brandId, int units, DateTime useBy)
        {
            Id = id;
            BrandId = brandId;
            Units = units;
            UseBy = useBy;
        }
    }
}