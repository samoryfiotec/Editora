using FluentValidation;
using Fiotec.Boletos.Domain.Entities;

namespace Fiotec.Boletos.Domain.Validators
{
    public class ContaValidator : AbstractValidator<Conta>
    {
        public ContaValidator()
		{
		RuleFor(c => c.Agencia)
			.NotEmpty().WithMessage("Agência é necessária.");

		RuleFor(c => c.Numero)
			.NotEmpty().WithMessage("Número da conta é necessário.");

		RuleFor(c => c.DigitoNumero)
			.NotEmpty().WithMessage("Dígito da conta é necessário.");

		RuleFor(c => c.Beneficiario)
			.NotEmpty().WithMessage("O valor do beneficiário é necessário.");

		RuleFor(c => c.DigitoAgencia)
			.MinimumLength(1).WithMessage("O Digito da Agencia deve ter no mínimo um caractere.")
			.When(c => c.DigitoAgencia != null);
		}
    }
}
