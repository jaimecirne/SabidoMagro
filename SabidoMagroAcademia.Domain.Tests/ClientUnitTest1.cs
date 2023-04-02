using FluentAssertions;
using SabidoMagroAcademia.Domain.Entities;
using SabidoMagroAcademia.Domain.Validation;
using System;
using Xunit;

namespace SabidoMagroAcademia.Domain.Tests
{
    public class ClientUnitTest1
    {
        [Fact]
        public void CreateProduct_WithValidParameters_ResultObjectValidState()
        {
            Action action = () => new Client(new User(1, "Product Name", "jaime@", "macho", DateTime.Now, "imagem"));

            action.Should()
                .NotThrow<DomainExceptionValidation>();
        }

        [Fact]
        public void CreateProduct_NegativeIdValue_DomainExceptionInvalidId()
        {
            Action action = () => new Client(new User(1, "Product Name", "jaime@", "macho", DateTime.Now, "imagem"));


            action.Should().Throw<DomainExceptionValidation>()
                .WithMessage("Invalid Id value.");
        }

        [Fact]
        public void CreateProduct_ShortNameValue_DomainExceptionShortName()
        {
            Action action = () => new Client(new User(1, "Product Name", "jaime@", "macho", DateTime.Now, "imagem"));

            action.Should().Throw<DomainExceptionValidation>()
                 .WithMessage("Invalid name, too short, minimum 3 characters");
        }

        [Fact]
        public void CreateProduct_LongImageName_DomainExceptionLongImageName()
        {
            Action action = () => new Client(new User(1, "Product Name", "jaime@", "macho", DateTime.Now, "imagem"));

            action.Should()
                .Throw<DomainExceptionValidation>()
                 .WithMessage("Invalid image name, too long, maximum 250 characters");
        }

        [Fact]
        public void CreateProduct_WithNullImageName_NoDomainException()
        {
            Action action = () => new Client(new User(1, "Product Name", "jaime@", "macho", DateTime.Now, "imagem"));

            action.Should().NotThrow<DomainExceptionValidation>();
        }

        [Fact]
        public void CreateProduct_WithNullImageName_NoNullReferenceException()
        {
            Action action = () => new Client(new User(1, "Product Name", "jaime@", "macho", DateTime.Now, "imagem"));
            action.Should().NotThrow<NullReferenceException>();
        }

        [Fact]
        public void CreateProduct_WithEmptyImageName_NoDomainException()
        {
            Action action = () => new Client(new User(1, "Product Name", "jaime@", "macho", DateTime.Now, "imagem"));
            action.Should().NotThrow<DomainExceptionValidation>();
        }

        [Fact]
        public void CreateProduct_InvalidPriceValue_DomainException()
        {
            Action action = () => new Client(new User(1, "Product Name", "jaime@", "macho", DateTime.Now, "imagem"));
            action.Should().Throw<DomainExceptionValidation>()
                 .WithMessage("Invalid price value");
        }

        [Theory]
        [InlineData(-5)]//usando atributos no teste
        public void CreateProduct_InvalidStockValue_ExceptionDomainNegativeValue(int value)
        {
            Action action = () => new Client(new User(1, "Product Name", "jaime@", "macho", DateTime.Now, "imagem"));

            action.Should().Throw<DomainExceptionValidation>()
                   .WithMessage("Invalid stock value");
        }

    }
}
