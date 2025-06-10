using Fiotec.Boleto.Domain.Entities;
using FluentValidation.TestHelper;

namespace Fiotec.Boleto.Tests.Domain.Entities
{
    public class StatusValidatorTests
    {
        private readonly StatusValidator _validator;

        public StatusValidatorTests()
        {
            _validator = new StatusValidator();
        }

        [Fact]
        public void Should_Pass_Validation_For_Valid_Status()
        {
            var status = new Status(1, "Ativo");
            var result = _validator.TestValidate(status);
            result.ShouldNotHaveAnyValidationErrors();
        }

        [Fact]
        public void Should_Fail_Validation_When_Id_Is_Zero()
        {
            var status = new Status(0, "Ativo");
            var result = _validator.TestValidate(status);
            result.ShouldHaveValidationErrorFor(s => s.Id);
        }

        [Fact]
        public void Should_Fail_Validation_When_Id_Is_Negative()
        {
            var status = new Status(-5, "Ativo");
            var result = _validator.TestValidate(status);
            result.ShouldHaveValidationErrorFor(s => s.Id);
        }

        [Fact]
        public void Should_Fail_Validation_When_Descricao_Is_Empty()
        {
            var status = new Status(1, "");
            var result = _validator.TestValidate(status);
            result.ShouldHaveValidationErrorFor(s => s.Descricao);
        }

        [Fact]
        public void Should_Fail_Validation_When_Descricao_Is_Null()
        {
            var status = new Status(1, null);
            var result = _validator.TestValidate(status);
            result.ShouldHaveValidationErrorFor(s => s.Descricao);
        }

        [Fact]
        public void Should_Fail_Validation_When_Descricao_Exceeds_MaxLength()
        {
            var longDescricao = new string('a', 256);
            var status = new Status(1, longDescricao);
            var result = _validator.TestValidate(status);
            result.ShouldHaveValidationErrorFor(s => s.Descricao);
        }
    }
}
