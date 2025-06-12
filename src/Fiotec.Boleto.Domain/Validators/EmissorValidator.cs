using FluentValidation;
using Fiotec.Boletos.Domain.Entities;

namespace Fiotec.Boletos.Domain.Validators
{
    public class EmissorValidator : AbstractValidator<Emissor>
    {
        public EmissorValidator()
        {
            RuleFor(e => e.Nome)
                .NotEmpty().WithMessage("Nome é obrigatório.")
                .MaximumLength(100).WithMessage("Nome deve ter no máximo 100 caracteres.");

            RuleFor(e => e.Cnpj)
                .NotEmpty().WithMessage("CNPJ é obrigatório.")
                .Length(14).WithMessage("CNPJ deve ter 14 caracteres.");

            RuleFor(e => e.Endereco)
                .NotEmpty().WithMessage("Endereço é obrigatório.")
                .MaximumLength(200).WithMessage("Endereço deve ter no máximo 200 caracteres.");

            RuleFor(e => e.Conta)
                .NotNull().WithMessage("Conta é obrigatória.");
        }
    }
}
