using System;
using System.Collections.Generic;
using System.Linq;
using Fiotec.Boletos.Domain.Entities;
using Moq;
using Xunit;

namespace Fiotec.Boletos.Tests.Domain.Validators
{
    public class BoletoValidatorTests
    {
        private readonly BoletoValidator _validator = new();

        private static Boleto CreateValidBoleto()
        {
            var status = new Status(1, "Ativo");
            var conta = new Conta("1234", "56789", "0", "237", "5");
            var endereco = new Endereco("Rua A", "123", "Cidade X", "SP", "12345-678");
            var cliente = new Cliente(1, "Cliente Teste", "123.456.789-00", endereco, "cliente@email.com");
            var faturamento = new Faturamento(DateTime.Now.AddDays(10), 1000.00m, cliente);
            var emissor = new Emissor("Banco Teste", "12345678000199", "Endereço Teste", conta);
            return new Boleto("123456", 100.00m, DateTime.Today.AddDays(5), status, emissor, faturamento);
        }

        [Fact]
        public void Validate_BoletoNull_ReturnsError()
        {
            var errors = _validator.Validate(null).ToList();
            Assert.Single(errors);
            Assert.Contains("Boleto não pode ser nulo.", errors);
        }

        [Fact]
        public void Validate_ValidBoleto_ReturnsNoErrors()
        {
            var boletoMock = new Mock<Boleto>();
            boletoMock.SetupAllProperties();
            boletoMock.Object.Numero = "123456";
            boletoMock.Object.Valor = 100.00m;
            boletoMock.Object.Vencimento = DateTime.Today.AddDays(5);
            boletoMock.Object.Status = new Status(1, "Ativo");
            boletoMock.Object.Emissor = new Emissor("Banco Teste", "12345678000199", "Endereço Teste", new Conta("1234", "56789", "0", "237", "5"));
            boletoMock.Object.Faturamento = new Faturamento(DateTime.Now.AddDays(10), 1000.00m, new Cliente(1, "Cliente Teste", "123.456.789-00", new Endereco("Rua A", "123", "Cidade X", "SP", "12345-678"), "cliente@email.com"));

            var errors = _validator.Validate(boletoMock.Object).ToList();
            Assert.Empty(errors);
        }

        [Fact]
        public void Validate_NumeroVazio_ReturnsNumeroObrigatorio()
        {
            var boletoMock = new Mock<Boleto>();
            boletoMock.SetupAllProperties();
            var boleto = CreateValidBoleto();
            boletoMock.Object.Numero = "";
            boletoMock.Object.Valor = boleto.Valor;
            boletoMock.Object.Vencimento = boleto.Vencimento;
            boletoMock.Object.Status = boleto.Status;
            boletoMock.Object.Emissor = boleto.Emissor;
            boletoMock.Object.Faturamento = boleto.Faturamento;

            var errors = _validator.Validate(boletoMock.Object).ToList();
            Assert.Contains("Número é obrigatório.", errors);
        }

        [Fact]
        public void Validate_ValorZeroOuNegativo_ReturnsValorMaiorQueZero()
        {
            var boletoMock = new Mock<Boleto>();
            boletoMock.SetupAllProperties();
            var boleto = CreateValidBoleto();
            boletoMock.Object.Numero = boleto.Numero;
            boletoMock.Object.Valor = 0;
            boletoMock.Object.Vencimento = boleto.Vencimento;
            boletoMock.Object.Status = boleto.Status;
            boletoMock.Object.Emissor = boleto.Emissor;
            boletoMock.Object.Faturamento = boleto.Faturamento;

            var errors = _validator.Validate(boletoMock.Object).ToList();
            Assert.Contains("Valor deve ser maior que zero.", errors);

            boletoMock.Object.Valor = -10;
            errors = _validator.Validate(boletoMock.Object).ToList();
            Assert.Contains("Valor deve ser maior que zero.", errors);
        }

        [Fact]
        public void Validate_VencimentoPadrao_ReturnsVencimentoObrigatorio()
        {
            var boletoMock = new Mock<Boleto>();
            boletoMock.SetupAllProperties();
            var boleto = CreateValidBoleto();
            boletoMock.Object.Numero = boleto.Numero;
            boletoMock.Object.Valor = boleto.Valor;
            boletoMock.Object.Vencimento = default;
            boletoMock.Object.Status = boleto.Status;
            boletoMock.Object.Emissor = boleto.Emissor;
            boletoMock.Object.Faturamento = boleto.Faturamento;

            var errors = _validator.Validate(boletoMock.Object).ToList();
            Assert.Contains("Ter um vencimento é obrigatório.", errors);
        }

        [Fact]
        public void Validate_StatusNulo_ReturnsStatusObrigatorio()
        {
            var boletoMock = new Mock<Boleto>();
            boletoMock.SetupAllProperties();
            var boleto = CreateValidBoleto();
            boletoMock.Object.Numero = boleto.Numero;
            boletoMock.Object.Valor = boleto.Valor;
            boletoMock.Object.Vencimento = boleto.Vencimento;
            boletoMock.Object.Status = null;
            boletoMock.Object.Emissor = boleto.Emissor;
            boletoMock.Object.Faturamento = boleto.Faturamento;

            var errors = _validator.Validate(boletoMock.Object).ToList();
            Assert.Contains("Estar em um status é obrigatório.", errors);
        }

        [Fact]
        public void Validate_EmissorNulo_ReturnsEmissorObrigatorio()
        {
            var boletoMock = new Mock<Boleto>();
            boletoMock.SetupAllProperties();
            var boleto = CreateValidBoleto();
            boletoMock.Object.Numero = boleto.Numero;
            boletoMock.Object.Valor = boleto.Valor;
            boletoMock.Object.Vencimento = boleto.Vencimento;
            boletoMock.Object.Status = boleto.Status;
            boletoMock.Object.Emissor = null;
            boletoMock.Object.Faturamento = boleto.Faturamento;

            var errors = _validator.Validate(boletoMock.Object).ToList();
            Assert.Contains("Tem o emissor é obrigatório.", errors);
        }

        [Fact]
        public void Validate_FaturamentoNulo_ReturnsFaturamentoObrigatorio()
        {
            var boletoMock = new Mock<Boleto>();
            boletoMock.SetupAllProperties();
            var boleto = CreateValidBoleto();
            boletoMock.Object.Numero = boleto.Numero;
            boletoMock.Object.Valor = boleto.Valor;
            boletoMock.Object.Vencimento = boleto.Vencimento;
            boletoMock.Object.Status = boleto.Status;
            boletoMock.Object.Emissor = boleto.Emissor;
            boletoMock.Object.Faturamento = null;

            var errors = _validator.Validate(boletoMock.Object).ToList();
            Assert.Contains("Faturamento é obrigatório.", errors);
        }

        [Fact]
        public void Validate_MultiplosErros_RetornaTodosOsErros()
        {
            var boletoMock = new Mock<Boleto>();
            boletoMock.SetupAllProperties();
            boletoMock.Object.Numero = "";
            boletoMock.Object.Valor = 0;
            boletoMock.Object.Vencimento = default;
            boletoMock.Object.Status = null;
            boletoMock.Object.Emissor = null;
            boletoMock.Object.Faturamento = null;

            var errors = _validator.Validate(boletoMock.Object).ToList();

            Assert.Contains("Número é obrigatório.", errors);
            Assert.Contains("Valor deve ser maior que zero.", errors);
            Assert.Contains("Ter um vencimento é obrigatório.", errors);
            Assert.Contains("Estar em um status é obrigatório.", errors);
            Assert.Contains("Tem o emissor é obrigatório.", errors);
            Assert.Contains("Faturamento é obrigatório.", errors);
            Assert.Equal(6, errors.Count);
        }
    }
}
