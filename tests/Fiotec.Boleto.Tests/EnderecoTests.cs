using Fiotec.Boletos.Domain.Entities;
using Xunit;

namespace Fiotec.Boletos.Tests.Domain.Entities
{
    public class EnderecoTests
    {
        [Fact]
        public void Construtor_ComTodosOsParametros_DeveConfigurarPropriedades()
        {
            // Arrange
            var logradouro = "Rua das Flores";
            var numero = "100";
            var cidade = "Rio de Janeiro";
            var estado = "RJ";
            var cep = "20000-000";
            var bairro = "Centro";

            // Act
            var endereco = new Endereco(logradouro, numero, cidade, estado, cep, bairro);

            // Assert
            Assert.Equal(logradouro, endereco.Logradouro);
            Assert.Equal(numero, endereco.Numero);
            Assert.Equal(cidade, endereco.Cidade);
            Assert.Equal(estado, endereco.Estado);
            Assert.Equal(cep, endereco.Cep);
            Assert.Equal(bairro, endereco.Bairro);
        }

        [Fact]
        public void Construtor_SemBairro_DeveConfigurarPropriedadesComBairroNulo()
        {
            // Arrange
            var logradouro = "Avenida Brasil";
            var numero = "200";
            var cidade = "São Paulo";
            var estado = "SP";
            var cep = "01000-000";

            // Act
            var endereco = new Endereco(logradouro, numero, cidade, estado, cep);

            // Assert
            Assert.Equal(logradouro, endereco.Logradouro);
            Assert.Equal(numero, endereco.Numero);
            Assert.Equal(cidade, endereco.Cidade);
            Assert.Equal(estado, endereco.Estado);
            Assert.Equal(cep, endereco.Cep);
            Assert.Null(endereco.Bairro);
        }

        [Fact]
        public void ConstrutorPadrao_DevePermitirSetarPropriedades()
        {
            // Arrange & Act
            var endereco = new Endereco
            {
                Logradouro = "Rua Nova",
                Numero = "300",
                Cidade = "Belo Horizonte",
                Estado = "MG",
                Cep = "30000-000",
                Bairro = "Savassi"
            };

            // Assert
            Assert.Equal("Rua Nova", endereco.Logradouro);
            Assert.Equal("300", endereco.Numero);
            Assert.Equal("Belo Horizonte", endereco.Cidade);
            Assert.Equal("MG", endereco.Estado);
            Assert.Equal("30000-000", endereco.Cep);
            Assert.Equal("Savassi", endereco.Bairro);
        }
    }
}
