using Fiotec.Boletos.Domain.Entities;

namespace Fiotec.Boletos.Tests.Domain.Entities
{
    public class BoletoTests
    {
        [Fact]
        public void Construtor_DeveConfigurarTodasPropriedades()
        {
            // Arrange
            string numero = "1234567890";
            decimal valor = 150.75m;
            DateTime vencimento = new DateTime(2024, 12, 31);
            var status = new Status(2, "Em aberto");
            var ContaNova = new Conta("1234", "56789", "0", "237", "5");
            var ClienteNovo = new Cliente(1, "João da Silva", "123.456.789-00", new Endereco("Rua A", "123", "Cidade X", "SP", "12345-678"), "joao@gmail.com");
            var Faturamento = new Faturamento(DateTime.Now.AddDays(30), 1000.00m, ClienteNovo);
            var Emissor = new Emissor("Banco XYZ", "123456789", "Agência 1234", ContaNova);

            // Act
            var boleto = new Boleto(numero, valor, vencimento, status, Emissor, Faturamento);

            // Assert
            Assert.Equal(numero, boleto.Numero);
            Assert.Equal(valor, boleto.Valor);
            Assert.Equal(vencimento, boleto.Vencimento);
            Assert.Equal(status, boleto.Status);
            Assert.Equal(Faturamento, boleto.Faturamento);
            Assert.Equal(Emissor, boleto.Emissor);
        }

        [Fact]
        public void Propriedades_DevemEstarConfiguradas()
        {
            // Arrange
            var boleto = new Boleto("", 0, DateTime.MinValue, new Status(0, ""), null, null);

            // Act
            boleto.Numero = "9876543210";
            boleto.Valor = 200.50m;
            boleto.Vencimento = new DateTime(2025, 1, 1);
            boleto.Status = new Status(3, "Pago");
            var ContaNova = new Conta("1234", "56789", "0", "237", "5");
            var ClienteNovo = new Cliente(1, "João da Silva", "123.456.789-00", new Endereco("Rua A", "123", "Cidade X", "SP", "12345-678"), "joao@gmail.com");
            var Faturamento = new Faturamento(DateTime.Now.AddDays(30), 1000.00m, ClienteNovo);
            var Emissor = new Emissor("Banco XYZ", "123456789", "Agência 1234", ContaNova);
            boleto.Emissor = Emissor;
            boleto.Faturamento = Faturamento;

            // Assert
            Assert.Equal("9876543210", boleto.Numero);
            Assert.Equal(200.50m, boleto.Valor);
            Assert.Equal(new DateTime(2025, 1, 1), boleto.Vencimento);
            Assert.Equal(3, boleto.Status.Id);
            Assert.Equal("Pago", boleto.Status.Descricao);
            Assert.Equal(Faturamento, boleto.Faturamento);
            Assert.Equal(Emissor, boleto.Emissor);
        }
    }
}
