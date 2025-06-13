using Fiotec.Boletos.Domain.Entities;
using Fiotec.Boletos.Domain.Validation;
using FluentValidation.TestHelper;
using Moq;

namespace Fiotec.Boletos.Tests.Domain.Validation
{
    public class FaturamentoValidatorTests
    {
        private readonly FaturamentoValidator _validator;

        public FaturamentoValidatorTests()
        {
            _validator = new FaturamentoValidator();
        }

        private Faturamento CriarFaturamentoValido()
        {
            var enderecoMock = new Mock<Endereco>("Rua X", "123", "Cidade", "UF", "00000-000", null);
            var clienteMock = new Mock<Cliente>(1, "Cliente Teste", "123.456.789-00", enderecoMock.Object, "cliente@email.com", null);
            var boletoMock = new Mock<Boleto>();
            var historicoMock = new Mock<Historico>();

            return new Faturamento(DateTime.Now.AddDays(-1), 100.0m, clienteMock.Object)
            {
                Boletos = new List<Boleto> { boletoMock.Object },
                Historicos = new List<Historico> { historicoMock.Object }
            };
        }

        [Fact]
        public void Deve_Aceitar_Faturamento_Valido()
        {
            var faturamento = CriarFaturamentoValido();
            var result = _validator.TestValidate(faturamento);
            result.ShouldNotHaveAnyValidationErrors();
        }

        [Fact]
        public void Deve_Falhar_Se_Data_Estiver_Vazia()
        {
            var faturamento = CriarFaturamentoValido();
            faturamento.Data = default;
            var result = _validator.TestValidate(faturamento);
            result.ShouldHaveValidationErrorFor(f => f.Data);
        }

        [Fact]
        public void Deve_Falhar_Se_Data_For_Futura()
        {
            var faturamento = CriarFaturamentoValido();
            faturamento.Data = DateTime.Now.AddDays(1);
            var result = _validator.TestValidate(faturamento);
            result.ShouldHaveValidationErrorFor(f => f.Data);
        }

        [Fact]
        public void Deve_Falhar_Se_Valor_For_Menor_Ou_Igual_A_Zero()
        {
            var faturamento = CriarFaturamentoValido();
            faturamento.Valor = 0;
            var result = _validator.TestValidate(faturamento);
            result.ShouldHaveValidationErrorFor(f => f.Valor);

            faturamento.Valor = -10;
            result = _validator.TestValidate(faturamento);
            result.ShouldHaveValidationErrorFor(f => f.Valor);
        }

        [Fact]
        public void Deve_Falhar_Se_Cliente_For_Nulo()
        {
            var faturamento = CriarFaturamentoValido();
            faturamento.Cliente = null;
            var result = _validator.TestValidate(faturamento);
            result.ShouldHaveValidationErrorFor(f => f.Cliente);
        }

        [Fact]
        public void Deve_Falhar_Se_Boletos_For_Nulo()
        {
            var faturamento = CriarFaturamentoValido();
            faturamento.Boletos = null;
            var result = _validator.TestValidate(faturamento);
            result.ShouldHaveValidationErrorFor(f => f.Boletos);
        }

        [Fact]
        public void Deve_Falhar_Se_Historicos_For_Nulo()
        {
            var faturamento = CriarFaturamentoValido();
            faturamento.Historicos = null;
            var result = _validator.TestValidate(faturamento);
            result.ShouldHaveValidationErrorFor(f => f.Historicos);
        }
    }
}
