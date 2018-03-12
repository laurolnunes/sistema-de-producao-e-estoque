using FluentValidation;
using SPE.Domain.Core.Models;
using System;
using System.Collections.Generic;

namespace SPE.Domain.Products
{
    public class Product : Entity<Product>
    {
        public Product(string name, string description)
        {
            Name = name;
            Description = description;
        }

        private Product()
        {
            
        }

        public string Name { get; private set; }

        public string Description { get; private set; }

        public DateTime Created { get; private set; }

        public bool HasComposition { get; private set; }

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

        public static class ProductFactory
        {
            public static Product CompleteProduct(int id, string name, string description)
            {
                var product = new Product()
                {
                    Id = id,
                    Name = name,
                    Description = description
                };
                return product;
            }
        }
    }
}