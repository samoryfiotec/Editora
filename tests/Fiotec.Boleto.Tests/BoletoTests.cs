using System;
using Fiotec.Boleto.Domain.Entities;
using Xunit;

namespace Fiotec.Boleto.Tests.Domain.Entities
{
    public class BoletoTests
    {
        [Fact]
        public void Construtor_DeveConfigurarTodasPropriedades()
        {
            // Arrange
            int id = 1;
            string numero = "1234567890";
            decimal valor = 150.75m;
            DateTime vencimento = new DateTime(2024, 12, 31);
            var status = new Status(2, "Em aberto");
            int faturamentoId = 10;

            // Act
            var boleto = new Fiotec.Boleto.Domain.Entities.Boleto(id, numero, valor, vencimento, status, faturamentoId);

            // Assert
            Assert.Equal(id, boleto.Id);
            Assert.Equal(numero, boleto.Numero);
            Assert.Equal(valor, boleto.Valor);
            Assert.Equal(vencimento, boleto.Vencimento);
            Assert.Equal(status, boleto.Status);
            Assert.Equal(faturamentoId, boleto.FaturamentoId);
        }

        [Fact]
        public void Propriedades_DevemEstarConfiguradas()
        {
            // Arrange
            var boleto = new Fiotec.Boleto.Domain.Entities.Boleto(0, "", 0, DateTime.MinValue, new Status(0, ""), 0);

            // Act
            boleto.Id = 5;
            boleto.Numero = "9876543210";
            boleto.Valor = 200.50m;
            boleto.Vencimento = new DateTime(2025, 1, 1);
            boleto.Status = new Status(3, "Pago");
            boleto.FaturamentoId = 20;

            // Assert
            Assert.Equal(5, boleto.Id);
            Assert.Equal("9876543210", boleto.Numero);
            Assert.Equal(200.50m, boleto.Valor);
            Assert.Equal(new DateTime(2025, 1, 1), boleto.Vencimento);
            Assert.Equal(3, boleto.Status.Id);
            Assert.Equal("Pago", boleto.Status.Descricao);
            Assert.Equal(20, boleto.FaturamentoId);
        }
    }
}
