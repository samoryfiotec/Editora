using FluentValidation;

namespace Fiotec.Boletos.Domain.Entities
{
    public class StatusValidator : AbstractValidator<Status>
    {
        public StatusValidator()
        {
            RuleFor(status => status.Id)
                .GreaterThan(0).WithMessage("Id deve ser maior que 0.");

            RuleFor(status => status.Descricao)
                .NotEmpty().WithMessage("Descrição é obrigatória.")
                .MaximumLength(255).WithMessage("Descrição deve ter no máximo 255 caracteres.");
        }
    }
}
