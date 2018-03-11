using System;
using System.Collections.Generic;
using System.Linq;
using FluentValidation;
using SPE.Domain.Core.Models;

namespace SPE.Domain.Products
{
    public class Product : Entity<Product>
    {
        public Product(string name)
        {
            Name = name;
        }

        public string Name { get; private set; }

        public int Description { get; private set; }

        public DateTime Created { get; private set; }

        public ICollection<Stock> Stocks { get; private set; }
        
        public override bool IsValid()
        {
            ValidateName();
            ValidationResult = Validate(this);

            return ValidationResult.IsValid;
        }

        private void ValidateName()
        {
            RuleFor(p => p.Name)
                .NotEmpty().WithMessage("Name parameter must be specified.")
                .Length(2, 150).WithMessage("Name parameter must be between 2 and 150 characters.");
        }
    }
}