using CleanArchMvc.Domain.Entities;
using FluentAssertions;
using System;
using Xunit;

namespace CleanArchMvc.Domain.Tests
{
    public class ProductUnitTest1
    {
        [Fact]
        public void CreateProduct_WithValidParameters_ResultObjectValidState()
        {
            Action action = () => new Product(1, "Product Name", "Product Description", 9.99m,
                99, "Product Image");
            action.Should().NotThrow<Validation.DomainExceptionValidation>();
        }

        [Fact]
        public void CreateProduct_NegativeIdValue_DomainExceptionInvalidId()
        {
            Action action = () => new Product(-1, "Product Name", "Product Description", 9.99m,
                99, "Product Image");
            action.Should().Throw<Validation.DomainExceptionValidation>()
                .WithMessage("Invalid Id value.");
        }

        [Fact]
        public void CreateProduct_MissingNameValue_DomainExceptionInvalidName()
        {
            Action action = () => new Product(1, "", "Product Description", 9.99m,
                 99, "Product Image");
            action.Should().Throw<Validation.DomainExceptionValidation>()
                .WithMessage("Invalid name. Name is required");
        }        

        [Fact]
        public void CreateProduct_ShortNameValue_DomainExceptionInvalidName()
        {
            Action action = () => new Product(1, "Pr", "Product Description", 9.99m,
                99, "Product Image");
            action.Should().Throw<Validation.DomainExceptionValidation>()
                .WithMessage("Invalid name. Too short, minimum 3 characters");
        }

        [Fact]
        public void CreateProduct_LongImageName_DomainExceptionInvalidName()
        {
            Action action = () => new Product(1, "Product Name", "Product Description", 9.99m,
                99, "Product Image toooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooo loooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooonnnnnnnnnnnnnnnng");
            action.Should().Throw<Validation.DomainExceptionValidation>()
                .WithMessage("Invalid image. Too large, maximum 250 characters");
        }

        [Fact]
        public void CreateProduct_WithNullImageName_NoDomainExceptionInvalidName()
        {
            Action action = () => new Product(1, "Product Name", "Product Description", 9.99m, 99, null);
            action.Should().NotThrow<Validation.DomainExceptionValidation>();
        }

        [Fact]
        public void CreateProduct_WithNullImageName_NoNullReferenceException()
        {
            Action action = () => new Product(1, "Product Name", "Product Description", 9.99m, 99, null);
            action.Should().NotThrow<NullReferenceException>();
        }

        [Fact]
        public void CreateProduct_WithEmptyImageName_NoDomainExceptionInvalidName()
        {
            Action action = () => new Product(1, "Product Name", "Product Description", 9.99m, 99, "");
            action.Should().NotThrow<Validation.DomainExceptionValidation>();
        }

        [Fact]
        public void CreateProduct_InvalidPriceValue_NoDomainExceptionInvalidName()
        {
            Action action = () => new Product(1, "Product Name", "Product Description", -9.99m, 99, null);
            action.Should().Throw<Validation.DomainExceptionValidation>()
                .WithMessage("Invalid price value");
        }


        [Theory]
        [InlineData(-5)]
        public void CreateProduct_InvalidStockValue_NoDomainExceptionInvalidName(int value)
        {
            Action action = () => new Product(1, "Pro", "Product Description", 9.99m, value, "product image");
            action.Should().Throw<Validation.DomainExceptionValidation>()
                .WithMessage("Invalid stock value");
        }
    }
}
