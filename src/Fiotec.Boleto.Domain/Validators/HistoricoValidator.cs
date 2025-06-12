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
                .WithMessage("Status � obrigat�rio.");

            RuleFor(h => h.Observacao)
                .NotEmpty()
                .WithMessage("Observa��o � obrigat�ria.")
                .MaximumLength(500)
                .WithMessage("Observa��o deve ter no m�ximo 500 caracteres.");

            RuleFor(h => h.DataInclusao)
                .NotEqual(default(DateTime))
                .WithMessage("Data de inclus�o � obrigat�ria.");

            RuleFor(h => h.Faturamento)
                .NotNull()
                .WithMessage("Faturamento � obrigat�rio.");

            RuleFor(h => h.FaturamentoId)
                .GreaterThan(0)
                .WithMessage("FaturamentoId deve ser maior que zero.");
        }
    }
}
