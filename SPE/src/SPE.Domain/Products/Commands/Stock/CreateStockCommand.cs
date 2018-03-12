using System;

namespace SPE.Domain.Products.Commands.Stock
{
    public class CreateStockCommand : BaseStockCommand
    {
        public CreateStockCommand(int productId, int brandId, int units, DateTime useBy)
        {
            ProductId = productId;
            BrandId = brandId;
            Units = units;
            UseBy = useBy;
        }
    }
}