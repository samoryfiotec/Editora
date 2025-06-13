using Xunit;
using Fiotec.Boletos.Domain.Entities;
using Fiotec.Boletos.Domain.Validators;
using FluentValidation.TestHelper;

public class ContaValidatorTests
{
    private readonly ContaValidator _validator = new();

    [Fact]
    public void Deve_Passar_Quando_Todos_Os_Campos_Sao_Validos()
    {
        var conta = new Conta("1234", "56789", "0", "123", "1");
        var result = _validator.TestValidate(conta);
        result.ShouldNotHaveAnyValidationErrors();
    }

    [Fact]
    public void Deve_Falhar_Quando_Agencia_Esta_Vazia()
    {
        var conta = new Conta("", "56789", "0", "123", "1");
        var result = _validator.TestValidate(conta);
        result.ShouldHaveValidationErrorFor(c => c.Agencia)
            .WithErrorMessage("Agência é necessária.");
    }

    [Fact]
    public void Deve_Falhar_Quando_Numero_Esta_Vazio()
    {
        var conta = new Conta("1234", "", "0", "123", "1");
        var result = _validator.TestValidate(conta);
        result.ShouldHaveValidationErrorFor(c => c.Numero)
            .WithErrorMessage("Número da conta é necessário.");
    }

    [Fact]
    public void Deve_Falhar_Quando_DigitoNumero_Esta_Vazio()
    {
        var conta = new Conta("1234", "56789", "", "123", "1");
        var result = _validator.TestValidate(conta);
        result.ShouldHaveValidationErrorFor(c => c.DigitoNumero)
            .WithErrorMessage("Dígito da conta é necessário.");
    }

    [Fact]
    public void Deve_Falhar_Quando_Beneficiario_Esta_Vazio()
    {
        var conta = new Conta("1234", "56789", "0", "", "1");
        var result = _validator.TestValidate(conta);
        result.ShouldHaveValidationErrorFor(c => c.Beneficiario)
            .WithErrorMessage("O valor do beneficiário é necessário.");
    }

    [Fact]
    public void Deve_Falhar_Quando_DigitoAgencia_Nao_E_Nulo_E_Esta_Vazio()
    {
        var conta = new Conta("1234", "56789", "0", "123", "");
        var result = _validator.TestValidate(conta);
        result.ShouldHaveValidationErrorFor(c => c.DigitoAgencia)
            .WithErrorMessage("O Digito da Agencia deve ter no mínimo um caractere.");
    }

    [Fact]
    public void Nao_Deve_Falhar_Quando_DigitoAgencia_E_Nulo()
    {
        var conta = new Conta("1234", "56789", "0", "123", null);
        var result = _validator.TestValidate(conta);
        result.ShouldNotHaveValidationErrorFor(c => c.DigitoAgencia);
    }
}
