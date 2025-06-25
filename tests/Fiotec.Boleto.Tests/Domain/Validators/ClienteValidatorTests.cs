using Fiotec.Boletos.Domain.Entities;
using Fiotec.Boletos.Domain.Validators;
using FluentValidation.TestHelper;
using Moq;

namespace Fiotec.Boletos.Tests.Domain.Validators
{
    public class ClienteValidatorTests
    {
        private readonly ClienteValidator _validator;

        public ClienteValidatorTests()
        {
            _validator = new ClienteValidator();
        }

        private Cliente CreateValidCliente()
        {
            var enderecoMock = new Mock<Endereco>();
            enderecoMock.SetupAllProperties();
            enderecoMock.Object.Logradouro = "Rua A";
            enderecoMock.Object.Numero = "123";
            enderecoMock.Object.Bairro = "Centro";
            enderecoMock.Object.Cidade = "Rio de Janeiro";
            enderecoMock.Object.Estado = "RJ";
            enderecoMock.Object.Cep = "12345678";

            var faturamentosMock = new Mock<ICollection<Faturamento>>();

            var clienteMock = new Mock<Cliente>();
            clienteMock.SetupAllProperties();
            clienteMock.Object.Id = 1;
            clienteMock.Object.Nome = "João da Silva";
            clienteMock.Object.Cpf = "12345678901";
            clienteMock.Object.Email = "joao@email.com";
            clienteMock.Object.Telefone = "21999999999";
            clienteMock.Object.Endereco = enderecoMock.Object;
            clienteMock.Object.Faturamentos = faturamentosMock.Object;

            return clienteMock.Object;
        }

        [Fact]
        public void Deve_Aceitar_Cliente_Valido()
        {
            var cliente = CreateValidCliente();
            var result = _validator.TestValidate(cliente);
            result.ShouldNotHaveAnyValidationErrors();
        }

        [Fact]
        public void Deve_Falhar_Quando_Nome_Eh_Vazio()
        {
            var cliente = CreateValidCliente();
            cliente.Nome = "";
            var result = _validator.TestValidate(cliente);
            result.ShouldHaveValidationErrorFor(c => c.Nome);
        }

        [Fact]
        public void Deve_Falhar_Quando_Nome_Eh_Muito_Grande()
        {
            var cliente = CreateValidCliente();
            cliente.Nome = new string('A', 101);
            var result = _validator.TestValidate(cliente);
            result.ShouldHaveValidationErrorFor(c => c.Nome);
        }

        [Fact]
        public void Deve_Falhar_Quando_Cpf_Eh_Vazio()
        {
            var cliente = CreateValidCliente();
            cliente.Cpf = "";
            var result = _validator.TestValidate(cliente);
            result.ShouldHaveValidationErrorFor(c => c.Cpf);
        }

        [Fact]
        public void Deve_Falhar_Quando_Cpf_Tem_Tamanho_Invalido()
        {
            var cliente = CreateValidCliente();
            cliente.Cpf = "123";
            var result = _validator.TestValidate(cliente);
            result.ShouldHaveValidationErrorFor(c => c.Cpf);
        }

        [Fact]
        public void Deve_Falhar_Quando_Cpf_Tem_Letras()
        {
            var cliente = CreateValidCliente();
            cliente.Cpf = "1234567890A";
            var result = _validator.TestValidate(cliente);
            result.ShouldHaveValidationErrorFor(c => c.Cpf);
        }

        [Fact]
        public void Deve_Falhar_Quando_Email_Eh_Vazio()
        {
            var cliente = CreateValidCliente();
            cliente.Email = "";
            var result = _validator.TestValidate(cliente);
            result.ShouldHaveValidationErrorFor(c => c.Email);
        }

        [Fact]
        public void Deve_Falhar_Quando_Email_Eh_Invalido()
        {
            var cliente = CreateValidCliente();
            cliente.Email = "emailinvalido";
            var result = _validator.TestValidate(cliente);
            result.ShouldHaveValidationErrorFor(c => c.Email);
        }

        [Fact]
        public void Deve_Falhar_Quando_Telefone_Maior_Que_20()
        {
            var cliente = CreateValidCliente();
            cliente.Telefone = new string('1', 21);
            var result = _validator.TestValidate(cliente);
            result.ShouldHaveValidationErrorFor(c => c.Telefone);
        }

        [Fact]
        public void Deve_Aceitar_Quando_Telefone_Nulo()
        {
            var cliente = CreateValidCliente();
            cliente.Telefone = null;
            var result = _validator.TestValidate(cliente);
            result.ShouldNotHaveValidationErrorFor(c => c.Telefone);
        }

        [Fact]
        public void Deve_Falhar_Quando_Endereco_Eh_Nulo()
        {
            var cliente = CreateValidCliente();
            cliente.Endereco = null;
            var result = _validator.TestValidate(cliente);
            result.ShouldHaveValidationErrorFor(c => c.Endereco);
        }

        [Fact]
        public void Deve_Falhar_Quando_Endereco_Eh_Invalido()
        {
            var enderecoMock = new Mock<Endereco>();
            enderecoMock.SetupAllProperties();
            enderecoMock.Object.Logradouro = "";
            enderecoMock.Object.Numero = "";
            enderecoMock.Object.Cidade = "";
            enderecoMock.Object.Estado = "";
            enderecoMock.Object.Cep = "123";

            var cliente = CreateValidCliente();
            cliente.Endereco = enderecoMock.Object;

            var result = _validator.TestValidate(cliente);
            result.ShouldHaveValidationErrorFor("Endereco.Logradouro");
            result.ShouldHaveValidationErrorFor("Endereco.Numero");
            result.ShouldHaveValidationErrorFor("Endereco.Cidade");
            result.ShouldHaveValidationErrorFor("Endereco.Estado");
            result.ShouldHaveValidationErrorFor("Endereco.Cep");
        }

        [Fact]
        public void Deve_Aceitar_Endereco_Valido()
        {
            var cliente = CreateValidCliente();
            var result = _validator.TestValidate(cliente);
            result.ShouldNotHaveValidationErrorFor(c => c.Endereco);
        }
    }
}
