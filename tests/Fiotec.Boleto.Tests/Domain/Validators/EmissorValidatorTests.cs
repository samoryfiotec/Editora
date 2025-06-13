using Fiotec.Boletos.Domain.Entities;
using Fiotec.Boletos.Domain.Validators;
using FluentValidation.TestHelper;
using Moq;

namespace Fiotec.Boletos.Tests.Domain.Validators
{
    public class EmissorValidatorTests
    {
        private readonly EmissorValidator _validator;

        public EmissorValidatorTests()
        {
            _validator = new EmissorValidator();
        }

        [Fact]
        public void Deve_Aceitar_Emissor_Valido()
        {
            var contaMock = new Mock<Conta>("1234", "56789", "0", "Beneficiario", "5");
            var emissor = new Emissor("Banco XYZ", "12345678901234", "Rua Exemplo, 123", contaMock.Object);

            var result = _validator.TestValidate(emissor);

            result.ShouldNotHaveAnyValidationErrors();
        }

        [Fact]
        public void Deve_Falhar_Quando_Nome_Eh_Vazio()
        {
            var contaMock = new Mock<Conta>("1234", "56789", "0", "Beneficiario", "5");
            var emissor = new Emissor("", "12345678901234", "Rua Exemplo, 123", contaMock.Object);

            var result = _validator.TestValidate(emissor);

            result.ShouldHaveValidationErrorFor(e => e.Nome);
        }

        [Fact]
        public void Deve_Falhar_Quando_Nome_Eh_Muito_Grande()
        {
            var contaMock = new Mock<Conta>("1234", "56789", "0", "Beneficiario", "5");
            var nome = new string('A', 101);
            var emissor = new Emissor(nome, "12345678901234", "Rua Exemplo, 123", contaMock.Object);

            var result = _validator.TestValidate(emissor);

            result.ShouldHaveValidationErrorFor(e => e.Nome);
        }

        [Fact]
        public void Deve_Falhar_Quando_Cnpj_Eh_Vazio()
        {
            var contaMock = new Mock<Conta>("1234", "56789", "0", "Beneficiario", "5");
            var emissor = new Emissor("Banco XYZ", "", "Rua Exemplo, 123", contaMock.Object);

            var result = _validator.TestValidate(emissor);

            result.ShouldHaveValidationErrorFor(e => e.Cnpj);
        }

        [Fact]
        public void Deve_Falhar_Quando_Cnpj_Tem_Tamanho_Incorreto()
        {
            var contaMock = new Mock<Conta>("1234", "56789", "0", "Beneficiario", "5");
            var emissor = new Emissor("Banco XYZ", "123", "Rua Exemplo, 123", contaMock.Object);

            var result = _validator.TestValidate(emissor);

            result.ShouldHaveValidationErrorFor(e => e.Cnpj);
        }

        [Fact]
        public void Deve_Falhar_Quando_Endereco_Eh_Vazio()
        {
            var contaMock = new Mock<Conta>("1234", "56789", "0", "Beneficiario", "5");
            var emissor = new Emissor("Banco XYZ", "12345678901234", "", contaMock.Object);

            var result = _validator.TestValidate(emissor);

            result.ShouldHaveValidationErrorFor(e => e.Endereco);
        }

        [Fact]
        public void Deve_Falhar_Quando_Endereco_Eh_Invalido()
        {
            var contaMock = new Mock<Conta>("1234", "56789", "0", "Beneficiario", "5");
            var endereco = new string('B', 201);
            var emissor = new Emissor("Banco XYZ", "12345678901234", endereco, contaMock.Object);

            var result = _validator.TestValidate(emissor);

            result.ShouldHaveValidationErrorFor(e => e.Endereco);
        }

        [Fact]
        public void Deve_Falhar_Quando_Conta_Eh_Nula()
        {
            var emissor = new Emissor("Banco XYZ", "12345678901234", "Rua Exemplo, 123", null);

            var result = _validator.TestValidate(emissor);

            result.ShouldHaveValidationErrorFor(e => e.Conta);
        }
    }
}
