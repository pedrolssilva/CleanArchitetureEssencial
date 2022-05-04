using CleanArchMvc.Domain.Entities;
using FluentAssertions;
using System;
using Xunit;

namespace CleanArchMvc.Domain.Tests
{
    public class CategoryUnitTest1
    {
        [Fact(DisplayName ="Create category with valid state")]
        public void CreateCategory_WithValidParameters_ResultObjectValidState()
        {
            Action action = () => new Category(1, "Category");
            action.Should().NotThrow<Validation.DomainExceptionValidation>();
        }

        [Fact]
        public void CreateCategory_NegativeIdValue_DomainExceptionInvalidId()
        {
            Action action = () => new Category(-1, "Category");
            action.Should().Throw<Validation.DomainExceptionValidation>()
                .WithMessage("Invalid Id value.") ;
        }

        [Fact]
        public void CreateCategory_ShortNameValue_DomainExceptionInvalidName()
        {
            Action action = () => new Category(1, "Ca");
            action.Should().Throw<Validation.DomainExceptionValidation>()
                .WithMessage("Invalid name. Too short, minimum 3 characters");
        }

        [Fact]
        public void CreateCategory_MissingNameValue_DomainExceptionInvalidName()
        {
            Action action = () => new Category(1, "");
            action.Should().Throw<Validation.DomainExceptionValidation>()
                .WithMessage("Invalid name. Name is required");
        }

        [Fact]
        public void CreateCategory_WithNullNameValue_DomainExceptionInvalidName()
        {
            Action action = () => new Category(1, null);
            action.Should().Throw<Validation.DomainExceptionValidation>()
                .WithMessage("Invalid name. Name is required");
        }
    }
}