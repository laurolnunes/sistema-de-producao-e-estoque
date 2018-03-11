using System;
using FluentValidation;
using SPE.Domain.Core.Models;

namespace SPE.Domain.Products
{
    public class Stock : Entity<Stock>
    {
        public int ProductId { get; set; }

        public int BrandId { get; set; }

        public int Units { get; set; }

        public DateTime LastUpdate { get; set; }

        public Brand Brand { get; set; }

        public Product Product { get; set; }

        public override bool IsValid()
        {
            ValidateUnits();
            ValidationResult = Validate(this);

            return ValidationResult.IsValid;
        }

        private void ValidateUnits()
        {
            RuleFor(s => s.Units)
                .GreaterThan(0)
                .WithMessage("Units parameter must be greater than zero.");
        }
    }
}