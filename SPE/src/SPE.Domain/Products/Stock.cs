using System;
using FluentValidation;
using SPE.Domain.Core.Models;

namespace SPE.Domain.Products
{
    public class Stock : Entity<Stock>
    {
        public Stock(int productId, int brandId, int units)
        {
            ProductId = productId;
            BrandId = brandId;
            Units = units;
        }

        private Stock()
        {

        }

        public int ProductId { get; set; }

        public int BrandId { get; set; }

        public int Units { get; set; }

        public DateTime UseBy { get; set; }

        public DateTime LastUpdate { get; set; }

        public Brand Brand { get; set; }

        public Product Product { get; set; }

        public override bool IsValid()
        {
            ValidateBrand();
            ValidateProduct();
            ValidationResult = Validate(this);

            return ValidationResult.IsValid;
        }

        private void ValidateBrand()
        {
            RuleFor(s => s.BrandId)
                .NotNull()
                .NotEqual(0)
                .WithMessage("You must specify a brand for the stock.");
        }

        private void ValidateProduct()
        {
            RuleFor(s => s.ProductId)
                .NotNull()
                .NotEqual(0)
                .WithMessage("You must specify a product for the stock.");
        }

        public static class StockFactory
        {
            public static Stock CompleteStock(int id, int productId, int brandId, int units, DateTime useBy)
            {
                var stock = new Stock
                {
                    Id = id,
                    ProductId = productId,
                    BrandId = brandId,
                    Units = units,
                    UseBy = useBy
                };
                return stock;
            }
        }
    }
}