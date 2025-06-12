using System;
using Fiotec.Boletos.Domain.Entities;
using Moq;
using Xunit;

namespace Fiotec.Boletos.Tests.Domain.Entities
{
    public class HistoricoTests
    {
        [Fact]
        public void Construtor_DeveConfigurarTodasPropriedades()
        {
            // Arrange
            var statusMock = new Mock<Status>(1, "Criado");
            var enderecoMock = new Mock<Endereco>("Rua X", "10", "Cidade Y", "RJ", "12345-000", null);
            var clienteMock = new Mock<Cliente>(1, "Maria", "123.456.789-00", enderecoMock.Object, "maria@email.com", null);
            var faturamentoMock = new Mock<Faturamento>(DateTime.Now, 500.00m, clienteMock.Object);
            string observacao = "Primeiro histórico";
            DateTime dataInclusao = new DateTime(2024, 6, 1, 10, 0, 0);

            // Act
            var historico = new Historico(statusMock.Object, observacao, dataInclusao, faturamentoMock.Object);

            // Assert
            Assert.Equal(statusMock.Object, historico.Status);
            Assert.Equal(observacao, historico.Observacao);
            Assert.Equal(dataInclusao, historico.DataInclusao);
            Assert.Equal(faturamentoMock.Object, historico.Faturamento);
            Assert.Equal(faturamentoMock.Object.Id, historico.FaturamentoId);
        }

        [Fact]
        public void Propriedades_DevemSerSetaveis()
        {
            // Arrange
            var historico = new Historico();
            var statusMock = new Mock<Status>(2, "Atualizado");
            var enderecoMock = new Mock<Endereco>("Rua Y", "20", "Cidade Z", "SP", "54321-000", null);
            var clienteMock = new Mock<Cliente>(2, "João", "987.654.321-00", enderecoMock.Object, "joao@email.com", null);
            var faturamentoMock = new Mock<Faturamento>(DateTime.Now.AddDays(1), 1000.00m, clienteMock.Object);
            string observacao = "Histórico alterado";
            DateTime dataInclusao = new DateTime(2024, 6, 2, 15, 30, 0);

            // Act
            historico.Status = statusMock.Object;
            historico.Observacao = observacao;
            historico.DataInclusao = dataInclusao;
            historico.Faturamento = faturamentoMock.Object;
            historico.FaturamentoId = faturamentoMock.Object.Id;
            historico.Id = 99;

            // Assert
            Assert.Equal(99, historico.Id);
            Assert.Equal(statusMock.Object, historico.Status);
            Assert.Equal(observacao, historico.Observacao);
            Assert.Equal(dataInclusao, historico.DataInclusao);
            Assert.Equal(faturamentoMock.Object, historico.Faturamento);
            Assert.Equal(faturamentoMock.Object.Id, historico.FaturamentoId);
        }

        [Fact]
        public void Construtor_DeveLancarExcecao_SeFaturamentoForNull()
        {
            // Arrange
            var statusMock = new Mock<Status>(1, "Criado");
            string observacao = "Teste";
            DateTime dataInclusao = DateTime.Now;

            // Act & Assert
            Assert.Throws<NullReferenceException>(() =>
            {
                var historico = new Historico(statusMock.Object, observacao, dataInclusao, null);
            });
        }
    }
}
