using System;
using Fiotec.Boleto.Domain.Entities;
using Xunit;

namespace Fiotec.Boleto.Tests.Domain.Entities
{
    public class ClienteTests
    {
        [Fact]
        public void Constructor_ShouldSetAllProperties_WithTelefone()
        {
            // Arrange
            int id = 1;
            string nome = "João Silva";
            string cpf = "123.456.789-00";
            var endereco = new Endereco("Rua A", "100", "CidadeX", "EstadoY", "12345-678", id, "Centro");
            string email = "joao@email.com";
            string telefone = "99999-8888";

            // Act
            var cliente = new Cliente(id, nome, cpf, endereco, email, telefone);

            // Assert
            Assert.Equal(id, cliente.Id);
            Assert.Equal(nome, cliente.Nome);
            Assert.Equal(cpf, cliente.Cpf);
            Assert.Equal(endereco, cliente.Endereco);
            Assert.Equal(email, cliente.Email);
            Assert.Equal(telefone, cliente.Telefone);
        }

        [Fact]
        public void Constructor_ShouldSetTelefoneToNull_WhenNotProvided()
        {
            // Arrange
            int id = 2;
            string nome = "Maria Souza";
            string cpf = "987.654.321-00";
            var endereco = new Endereco("Av. B", "200", "CidadeY", "EstadoZ", "87654-321", id);
            string email = "maria@email.com";

            // Act
            var cliente = new Cliente(id, nome, cpf, endereco, email);

            // Assert
            Assert.Equal(id, cliente.Id);
            Assert.Equal(nome, cliente.Nome);
            Assert.Equal(cpf, cliente.Cpf);
            Assert.Equal(endereco, cliente.Endereco);
            Assert.Equal(email, cliente.Email);
            Assert.Null(cliente.Telefone);
        }

        [Fact]
        public void Properties_ShouldBeSettable()
        {
            // Arrange
            var endereco1 = new Endereco("Rua C", "300", "CidadeZ", "EstadoW", "11223-445", 3);
            var endereco2 = new Endereco("Rua D", "400", "CidadeW", "EstadoV", "99887-665", 4, "Bairro Novo");
            var cliente = new Cliente(0, "", "", endereco1, "");

            // Act
            cliente.Id = 10;
            cliente.Nome = "Carlos Lima";
            cliente.Cpf = "111.222.333-44";
            cliente.Endereco = endereco2;
            cliente.Email = "carlos@email.com";
            cliente.Telefone = "88888-7777";

            // Assert
            Assert.Equal(10, cliente.Id);
            Assert.Equal("Carlos Lima", cliente.Nome);
            Assert.Equal("111.222.333-44", cliente.Cpf);
            Assert.Equal(endereco2, cliente.Endereco);
            Assert.Equal("carlos@email.com", cliente.Email);
            Assert.Equal("88888-7777", cliente.Telefone);
        }
    }
}
