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
                .NotEmpty().WithMessage("Descri��o � obrigat�ria.")
                .MaximumLength(255).WithMessage("Descri��o deve ter no m�ximo 255 caracteres.");
        }
    }
}
