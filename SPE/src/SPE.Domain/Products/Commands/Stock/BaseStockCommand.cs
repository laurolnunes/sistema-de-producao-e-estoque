using System;
using SPE.Domain.Core.Commands;

namespace SPE.Domain.Products.Commands.Stock
{
    public class BaseStockCommand : Command
    {
        public int Id { get; set; }

        public int ProductId { get; set; }

        public int BrandId { get; set; }

        public int Units { get; set; }

        public DateTime UseBy { get; set; }
    }
}