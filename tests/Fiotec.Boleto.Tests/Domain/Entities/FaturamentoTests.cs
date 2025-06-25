using System;
using System.Collections.Generic;
using Fiotec.Boletos.Domain.Entities;
using Xunit;

namespace Fiotec.Boletos.Tests.Domain.Entities
{
    public class FaturamentoTests
    {
        [Fact]
        public void Construtor_DeveConfigurarTodasPropriedades()
        {
            // Arrange
            var data = new DateTime(2024, 6, 1);
            decimal valor = 500.00m;
            var cliente = new Cliente(1, "Maria Souza", "111.222.333-44", new Endereco("Rua B", "456", "Cidade Y", "RJ", "22222-333"), "maria@email.com");

            // Act
            var faturamento = new Faturamento(data, valor, cliente);

            // Assert
            Assert.Equal(data, faturamento.Data);
            Assert.Equal(valor, faturamento.Valor);
            Assert.Equal(cliente, faturamento.Cliente);
            Assert.NotNull(faturamento.Boletos);
            Assert.NotNull(faturamento.Historicos);
            Assert.Empty(faturamento.Boletos);
            Assert.Empty(faturamento.Historicos);
        }

        [Fact]
        public void ConstrutorPadrao_DeveInicializarColecoes()
        {
            // Act
            var faturamento = new Faturamento();

            // Assert
            Assert.NotNull(faturamento.Boletos);
            Assert.NotNull(faturamento.Historicos);
            Assert.Empty(faturamento.Boletos);
            Assert.Empty(faturamento.Historicos);
        }

        [Fact]
        public void Propriedades_DevemSerLidasEEscritas()
        {
            // Arrange
            var faturamento = new Faturamento();
            var data = new DateTime(2023, 1, 1);
            decimal valor = 123.45m;
            var cliente = new Cliente(2, "Carlos Lima", "555.666.777-88", new Endereco("Av. Central", "789", "Cidade Z", "MG", "33333-444"), "carlos@email.com");
            var boletos = new List<Fiotec.Boletos.Domain.Entities.Boleto>
            {
                new Fiotec.Boletos.Domain.Entities.Boleto("123", 100, DateTime.Now, new Status(1, "Novo"), null, faturamento)
            };
            var historicos = new List<Historico>
            {
                new Historico(new Status(1, "Criado"), "Observação", DateTime.Now, faturamento)
            };

            // Act
            faturamento.Id = 10;
            faturamento.Data = data;
            faturamento.Valor = valor;
            faturamento.Cliente = cliente;
            faturamento.Boletos = boletos;
            faturamento.Historicos = historicos;

            // Assert
            Assert.Equal(10, faturamento.Id);
            Assert.Equal(data, faturamento.Data);
            Assert.Equal(valor, faturamento.Valor);
            Assert.Equal(cliente, faturamento.Cliente);
            Assert.Equal(boletos, faturamento.Boletos);
            Assert.Equal(historicos, faturamento.Historicos);
        }
    }
}
