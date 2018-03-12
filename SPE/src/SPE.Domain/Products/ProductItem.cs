using System.Reflection.Metadata;
using FluentValidation;
using SPE.Domain.Core.Models;

namespace SPE.Domain.Products
{
    public class ProductItem : Entity<ProductItem>
    {
        public ProductItem(int productId, int productItemId, int units)
        {
            ProductId = productId;
            ProductItemId = productItemId;
            Units = units;
        }

        private ProductItem()
        {

        }

        public int ProductId { get; set; }

        public int ProductItemId { get; set; }

        public int Units { get; set; }

        public override bool IsValid()
        {
            ValidateProduct();
            ValidateProductItem();
            ValidateUnits();
            ValidationResult = Validate(this);

            return ValidationResult.IsValid;
        }

        public void ValidateProduct()
        {
            RuleFor(p => p.ProductId)
                .NotEqual(0)
                .NotNull()
                .WithMessage("You must specify a parent product for the item.");
        }

        public void ValidateProductItem()
        {
            RuleFor(p => p.ProductItemId)
                .NotEqual(0)
                .NotNull()
                .WithMessage("You must specify an item product for the item.");
        }

        public void ValidateUnits()
        {
            RuleFor(p => p.Units)
                .GreaterThan(0)
                .NotNull()
                .WithMessage("You must specify the number of items.");
        }

        public static class ProductItemFactory
        {
            public static ProductItem CompleteProductItem(int id, int productId, int productItemId, int units)
            {
                var productItem = new ProductItem
                {
                    Id = id,
                    ProductId = productId,
                    ProductItemId = productItemId,
                    Units = units
                };
                return productItem;
            }
        }
    }
}