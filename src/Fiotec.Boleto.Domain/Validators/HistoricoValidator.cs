using Fiotec.Boletos.Domain.Entities;
using FluentValidation;

namespace Fiotec.Boletos.Domain.Validators
{
    public class HistoricoValidator : AbstractValidator<Historico>
    {
        public HistoricoValidator()
        {
            RuleFor(h => h.Status)
                .NotNull()
                .WithMessage("Status é obrigatório.");

            RuleFor(h => h.Observacao)
                .NotEmpty()
                .WithMessage("Observação é obrigatória.")
                .MaximumLength(500)
                .WithMessage("Observação deve ter no máximo 500 caracteres.");

            RuleFor(h => h.DataInclusao)
                .NotEqual(default(DateTime))
                .WithMessage("Data de inclusão é obrigatória.");

            RuleFor(h => h.Faturamento)
                .NotNull()
                .WithMessage("Faturamento é obrigatório.");

            RuleFor(h => h.FaturamentoId)
                .GreaterThan(0)
                .WithMessage("FaturamentoId deve ser maior que zero.");
        }
    }
}
