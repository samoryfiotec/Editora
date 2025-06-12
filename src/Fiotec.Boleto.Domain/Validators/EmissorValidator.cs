using FluentValidation;
using Fiotec.Boletos.Domain.Entities;

namespace Fiotec.Boletos.Domain.Validators
{
    public class EmissorValidator : AbstractValidator<Emissor>
    {
        public EmissorValidator()
        {
            RuleFor(e => e.Nome)
                .NotEmpty().WithMessage("Nome � obrigat�rio.")
                .MaximumLength(100).WithMessage("Nome deve ter no m�ximo 100 caracteres.");

            RuleFor(e => e.Cnpj)
                .NotEmpty().WithMessage("CNPJ � obrigat�rio.")
                .Length(14).WithMessage("CNPJ deve ter 14 caracteres.");

            RuleFor(e => e.Endereco)
                .NotEmpty().WithMessage("Endere�o � obrigat�rio.")
                .MaximumLength(200).WithMessage("Endere�o deve ter no m�ximo 200 caracteres.");

            RuleFor(e => e.Conta)
                .NotNull().WithMessage("Conta � obrigat�ria.");
        }
    }
}
