using Fiotec.Boletos.Domain.Entities;

namespace Fiotec.Boletos.Tests.Domain.Entities
{
    public class ClienteTests
    {
        [Fact]
        public void Construtor_Deve_Definir_Todas_As_Propriedades_Com_Telefone()
        {
            // Arrange
            int id = 1;
            string nome = "João Carlos de Andrade e Silva";
            string cpf = "123.456.789-00";
            var endereco = new Endereco("Rua dos Andradas", "181", "Rio de Janeiro", "RJ", "20000-005", "Centro");
            string email = "joaocarlosas@gmail.com";
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
        public void Construtor_Deve_Definir_Telefone_Com_Nulo_Quando_Nao_For_Informado()
        {
            // Arrange
            int id = 2;
            string nome = "Maria do Socorro de Souza";
            string cpf = "987.654.321-00";
            var endereco = new Endereco("Avenida Presidente Vargas", "278", "Varginha", "MG", "87654-321");
            string email = "mariasocsouza@gmail.com";

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
        public void Propriedades_Devem_Permitir_Atribuicao()
        {
            // Arrange
            var endereco1 = new Endereco("Rua Camerino", "300", "Sorocaba", "SP", "11223-445");
            var endereco2 = new Endereco("Rua Direita", "400", "Palmas", "TO", "99887-665", "Bairro Novo");
            var cliente = new Cliente(0, "", "", endereco1, "");

            // Act
            cliente.Id = 10;
            cliente.Nome = "Carlos Lima";
            cliente.Cpf = "111.222.333-44";
            cliente.Endereco = endereco2;
            cliente.Email = "carloslima@gmail.com";
            cliente.Telefone = "88888-7777";

            // Assert
            Assert.Equal(10, cliente.Id);
            Assert.Equal("Carlos Lima", cliente.Nome);
            Assert.Equal("111.222.333-44", cliente.Cpf);
            Assert.Equal(endereco2, cliente.Endereco);
            Assert.Equal("carloslima@gmail.com", cliente.Email);
            Assert.Equal("88888-7777", cliente.Telefone);
        }
    }
}
