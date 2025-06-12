using FluentValidation;
using Fiotec.Boletos.Domain.Entities;

namespace Fiotec.Boletos.Domain.Validators
{
    public class ContaValidator : AbstractValidator<Conta>
    {
        public ContaValidator()
        {
            RuleFor(c => c.Agencia)
                .NotEmpty().WithMessage("Agencia is required.");

            RuleFor(c => c.Numero)
                .NotEmpty().WithMessage("Numero is required.");

            RuleFor(c => c.DigitoNumero)
                .NotEmpty().WithMessage("DigitoNumero is required.");

            RuleFor(c => c.Beneficiario)
                .NotEmpty().WithMessage("Beneficiario is required.");

            RuleFor(c => c.DigitoAgencia)
                .MaximumLength(2).WithMessage("DigitoAgencia must be at most 2 characters.")
                .When(c => c.DigitoAgencia != null);
        }
    }
}
