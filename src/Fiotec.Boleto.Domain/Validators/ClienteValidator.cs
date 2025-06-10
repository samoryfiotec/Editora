using Fiotec.Boleto.Domain.Entities;
using FluentValidation;

namespace Fiotec.Boleto.Domain.Validators
{
    public class ClienteValidator : AbstractValidator<Cliente>
    {
        public ClienteValidator()
        {
            RuleFor(c => c.Nome)
                .NotEmpty().WithMessage("O nome � obrigat�rio.")
                .MaximumLength(100).WithMessage("O nome deve ter no m�ximo 100 caracteres.");

            RuleFor(c => c.Cpf)
                .NotEmpty().WithMessage("O CPF � obrigat�rio.")
                .Length(11).WithMessage("O CPF deve ter 11 caracteres.")
                .Matches(@"^\d{11}$").WithMessage("O CPF deve conter apenas n�meros.");

            RuleFor(c => c.Email)
                .NotEmpty().WithMessage("O e-mail � obrigat�rio.")
                .EmailAddress().WithMessage("O e-mail informado n�o � v�lido.");

            RuleFor(c => c.Telefone)
                .MaximumLength(20).WithMessage("O telefone deve ter no m�ximo 20 caracteres.")
                .When(c => !string.IsNullOrEmpty(c.Telefone));

            RuleFor(c => c.Endereco)
                .NotNull().WithMessage("O endere�o � obrigat�rio.")
                .SetValidator(new EnderecoValidator());
        }
    }

    public class EnderecoValidator : AbstractValidator<Endereco>
    {
        public EnderecoValidator()
        {
            RuleFor(e => e.Logradouro)
                .NotEmpty().WithMessage("O logradouro � obrigat�rio.");

            RuleFor(e => e.Numero)
                .NotEmpty().WithMessage("O n�mero � obrigat�rio.");

            RuleFor(e => e.Cidade)
                .NotEmpty().WithMessage("A cidade � obrigat�ria.");

            RuleFor(e => e.Estado)
                .NotEmpty().WithMessage("O estado � obrigat�rio.");

            RuleFor(e => e.Cep)
                .NotEmpty().WithMessage("O CEP � obrigat�rio.")
                .Matches(@"^\d{8}$").WithMessage("O CEP deve conter 8 d�gitos num�ricos.");
        }
    }
}
