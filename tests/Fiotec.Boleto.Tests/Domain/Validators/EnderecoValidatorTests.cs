using Fiotec.Boletos.Domain.Entities;
using Fiotec.Boletos.Domain.Validators;
using FluentValidation.TestHelper;

namespace Fiotec.Boletos.Tests.Domain.Validators
{
    public class EnderecoValidatorTests
    {
        private readonly EnderecoValidator _validator;
        public EnderecoValidatorTests()
        {
            _validator = new EnderecoValidator();
        }
        private Endereco CreateValidEndereco()
        {
            return new Endereco
            {
                Logradouro = "Rua A",
                Numero = "123",
                Bairro = "Centro",
                Cidade = "Rio de Janeiro",
                Estado = "RJ",
                Cep = "12345678"
            };
        }
        [Fact]
        public void Deve_Aceitar_Endereco_Valido()
        {
            var endereco = CreateValidEndereco();
            var result = _validator.TestValidate(endereco);
            result.ShouldNotHaveAnyValidationErrors();
        }
        [Fact]
        public void Deve_Falhar_Quando_Logradouro_Eh_Vazio()
        {
            var endereco = CreateValidEndereco();
            endereco.Logradouro = "";
            var result = _validator.TestValidate(endereco);
            result.ShouldHaveValidationErrorFor(e => e.Logradouro);
        }
        [Fact]
        public void Deve_Falhar_Quando_Numero_Eh_Vazio()
        {
            var endereco = CreateValidEndereco();
            endereco.Numero = "";
            var result = _validator.TestValidate(endereco);
            result.ShouldHaveValidationErrorFor(e => e.Numero);
        }
        [Fact]
        public void Deve_Falhar_Quando_Cidade_Eh_Vazia()
        {
            var endereco = CreateValidEndereco();
            endereco.Cidade = "";
            var result = _validator.TestValidate(endereco);
            result.ShouldHaveValidationErrorFor(e => e.Cidade);
        }
        [Fact]
        public void Deve_Falhar_Quando_Estado_Eh_Vazio()
        {
            var endereco = CreateValidEndereco();
            endereco.Estado = "";
            var result = _validator.TestValidate(endereco);
            result.ShouldHaveValidationErrorFor(e => e.Estado);
        }
        [Fact]
        public void Deve_Falhar_Quando_Cep_Eh_Vazio()
        {
            var endereco = CreateValidEndereco();
            endereco.Cep = "";
            var result = _validator.TestValidate(endereco);
            result.ShouldHaveValidationErrorFor(e => e.Cep);
        }
        [Fact]
        public void Deve_Falhar_Quando_Cep_Eh_Invalido()
        {
            var endereco = CreateValidEndereco();
            endereco.Cep = "1234"; // CEP deve ter 8 dígitos.
        }
    }
}
