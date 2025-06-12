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
        public void Deve_Passar_Validacao_Para_Status_Valido()
        {
            var status = new Status(1, "Aguardando pagamento");
            var result = _validator.TestValidate(status);
            result.ShouldNotHaveAnyValidationErrors();
        }

        [Fact]
        public void Deve_Falhar_Validacao_Quando_Id_For_Zero()
        {
            var status = new Status(0, "Ativo");
            var result = _validator.TestValidate(status);
            result.ShouldHaveValidationErrorFor(s => s.Id);
        }

        [Fact]
        public void Deve_Falhar_Validacao_Quando_Id_For_Negativo()
        {
            var status = new Status(-5, "Desestruturado");
            var result = _validator.TestValidate(status);
            result.ShouldHaveValidationErrorFor(s => s.Id);
        }

        [Fact]
        public void Deve_Falhar_Validacao_Quando_Descricao_Estiver_Vazia()
        {
            var status = new Status(1, "");
            var result = _validator.TestValidate(status);
            result.ShouldHaveValidationErrorFor(s => s.Descricao);
        }

        [Fact]
        public void Deve_Falhar_Validacao_Quando_Descricao_For_Nula()
        {
            var status = new Status(1, null);
            var result = _validator.TestValidate(status);
            result.ShouldHaveValidationErrorFor(s => s.Descricao);
        }

        [Fact]
        public void Deve_Falhar_Validacao_Quando_Descricao_Ultrapassar_Tamanho_Maximo()
        {
            var longDescricao = new string('a', 256);
            var status = new Status(1, longDescricao);
            var result = _validator.TestValidate(status);
            result.ShouldHaveValidationErrorFor(s => s.Descricao);
        }
    }
}
