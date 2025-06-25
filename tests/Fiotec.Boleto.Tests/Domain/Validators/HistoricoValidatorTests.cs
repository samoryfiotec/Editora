using System;
using Fiotec.Boletos.Domain.Entities;
using Fiotec.Boletos.Domain.Validators;
using FluentValidation.TestHelper;
using Xunit;

namespace Fiotec.Boletos.Tests.Domain.Validators
{
    public class HistoricoValidatorTests
    {
        private readonly HistoricoValidator _validator;

        public HistoricoValidatorTests()
        {
            _validator = new HistoricoValidator();
        }

        private Historico CreateValidHistorico()
        {
            var status = new Status(1, "Ativo");
            var cliente = new Cliente(1, "Cliente Teste", "123.456.789-00", new Endereco("Rua X", "123", "Cidade", "UF", "00000-000"), "cliente@email.com");
            var faturamento = new Faturamento(DateTime.Now, 1000m, cliente);
            return new Historico(status, "Observação válida", DateTime.Now, faturamento)
            {
                FaturamentoId = 1
            };
        }

        [Fact]
        public void Validator_Should_Pass_With_Valid_Historico()
        {
            var historico = CreateValidHistorico();
            var result = _validator.TestValidate(historico);
            result.ShouldNotHaveAnyValidationErrors();
        }

        [Fact]
        public void Validator_Should_Fail_When_Status_Is_Null()
        {
            var historico = CreateValidHistorico();
            historico.Status = null;
            var result = _validator.TestValidate(historico);
            result.ShouldHaveValidationErrorFor(h => h.Status)
                .WithErrorMessage("Status é obrigatório.");
        }

        [Fact]
        public void Validator_Should_Fail_When_Observacao_Is_Empty()
        {
            var historico = CreateValidHistorico();
            historico.Observacao = "";
            var result = _validator.TestValidate(historico);
            result.ShouldHaveValidationErrorFor(h => h.Observacao)
                .WithErrorMessage("Observação é obrigatória.");
        }

        [Fact]
        public void Validator_Should_Fail_When_Observacao_Exceeds_MaxLength()
        {
            var historico = CreateValidHistorico();
            historico.Observacao = new string('a', 501);
            var result = _validator.TestValidate(historico);
            result.ShouldHaveValidationErrorFor(h => h.Observacao)
                .WithErrorMessage("Observação deve ter no máximo 500 caracteres.");
        }

        [Fact]
        public void Validator_Should_Fail_When_DataInclusao_Is_Default()
        {
            var historico = CreateValidHistorico();
            historico.DataInclusao = default;
            var result = _validator.TestValidate(historico);
            result.ShouldHaveValidationErrorFor(h => h.DataInclusao)
                .WithErrorMessage("Data de inclusão é obrigatória.");
        }

        [Fact]
        public void Validator_Should_Fail_When_Faturamento_Is_Null()
        {
            var historico = CreateValidHistorico();
            historico.Faturamento = null;
            var result = _validator.TestValidate(historico);
            result.ShouldHaveValidationErrorFor(h => h.Faturamento)
                .WithErrorMessage("Faturamento é obrigatório.");
        }

        [Theory]
        [InlineData(0)]
        [InlineData(-1)]
        public void Validator_Should_Fail_When_FaturamentoId_Is_Not_Greater_Than_Zero(int faturamentoId)
        {
            var historico = CreateValidHistorico();
            historico.FaturamentoId = faturamentoId;
            var result = _validator.TestValidate(historico);
            result.ShouldHaveValidationErrorFor(h => h.FaturamentoId)
                .WithErrorMessage("FaturamentoId deve ser maior que zero.");
        }
    }
}
