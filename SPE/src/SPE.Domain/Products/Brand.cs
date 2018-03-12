using System;
using System.Collections.Generic;
using FluentValidation;
using SPE.Domain.Core.Models;

namespace SPE.Domain.Products
{
    public class Brand : Entity<Brand>
    {
        public Brand(string name)
        {
            Name = name;
        }

        private Brand()
        {

        }

        public string Name { get; private set; }

        public DateTime Created { get; private set; }

        public ICollection<Product> Products { get; private set; }

        public override bool IsValid()
        {
            ValidateName();
            ValidationResult = Validate(this);

            return ValidationResult.IsValid;
        }

        public void ValidateName()
        {
            RuleFor(p => p.Name)
                .NotEmpty().WithMessage("Name parameter must be specified.")
                .Length(2, 150).WithMessage("Name parameter must be between 2 and 150 characters.");
        }

        public static class BrandFactory
        {
            public static Brand CompleteBrand(int id, string name)
            {
                var brand = new Brand
                {
                    Id = id,
                    Name = name
                };
                return brand;
            }
        }
    }
}