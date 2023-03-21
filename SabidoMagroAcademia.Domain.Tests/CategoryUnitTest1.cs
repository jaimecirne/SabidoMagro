using FluentAssertions;
using SabidoMagroAcademia.Domain.Entities;
using SabidoMagroAcademia.Domain.Validation;
using System;
using Xunit;

namespace SabidoMagroAcademia.Domain.Tests
{
    public class planUnitTest1
    {
        //DisplayName renomeia o teste
        [Fact(DisplayName = "Create plan With Valid State")]
        public void Createplan_WithValidParameters_ResultObjectValidState()
        {
            //criando uma instancia da classe plan
            //esperasse que o teste não lance uma exceção no dominio
            Action action = () => new Plan(1, "plan Name ");
            action.Should()
                .NotThrow<DomainExceptionValidation>();
        }

        [Fact]
        public void Createplan_NegativeIdValue_DomainExceptionInvalidId()
        {
            Action action = () => new Plan(-1, "plan Name ");
            action.Should()
                .Throw<DomainExceptionValidation>()//espera-se que lance uma exceção
                 .WithMessage("Invalid Id value.");//teste valida se a mensagem de erro está como foi definida na classe
        }

        [Fact]
        public void Createplan_ShortNameValue_DomainExceptionShortName()
        {
            Action action = () => new Plan(1, "Ca");//testa regra de negócio (não pode ser menor que 3 caracteres)
            action.Should()
                .Throw<DomainExceptionValidation>()
                   .WithMessage("Invalid name, too short, minimum 3 characters");
        }

        [Fact]
        public void Createplan_MissingNameValue_DomainExceptionRequiredName()
        {
            Action action = () => new Plan(1, "");
            action.Should()
                .Throw<DomainExceptionValidation>()
                .WithMessage("Invalid name.Name is required");
        }

        [Fact]
        public void Createplan_WithNullNameValue_DomainExceptionInvalidName()
        {
            Action action = () => new Plan(1, null);
            action.Should()
                .Throw<DomainExceptionValidation>();
        }
    }
}
