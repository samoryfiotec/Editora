using System;
using FluentValidation;
using Fiotec.Boletos.Domain.Entities;

namespace Fiotec.Boletos.Domain.Validation
{
    public class FaturamentoValidator : AbstractValidator<Faturamento>
    {
        public FaturamentoValidator()
        {
            RuleFor(f => f.Data)
                .NotEmpty().WithMessage("A data do faturamento é obrigatória.")
                .LessThanOrEqualTo(DateTime.Now).WithMessage("A data do faturamento não pode ser futura.");

            RuleFor(f => f.Valor)
                .GreaterThan(0).WithMessage("O valor do faturamento deve ser maior que zero.");

            RuleFor(f => f.Cliente)
                .NotNull().WithMessage("O cliente é obrigatório.");

            RuleFor(f => f.Boletos)
                .NotNull().WithMessage("A lista de boletos não pode ser nula.");

            RuleFor(f => f.Historicos)
                .NotNull().WithMessage("A lista de históricos não pode ser nula.");
        }
    }
}
