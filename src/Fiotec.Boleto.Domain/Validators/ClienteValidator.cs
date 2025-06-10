using Fiotec.Boleto.Domain.Entities;
using FluentValidation;

namespace Fiotec.Boleto.Domain.Validators
{
    public class ClienteValidator : AbstractValidator<Cliente>
    {
        public ClienteValidator()
        {
            RuleFor(c => c.Nome)
                .NotEmpty().WithMessage("O nome é obrigatório.")
                .MaximumLength(100).WithMessage("O nome deve ter no máximo 100 caracteres.");

            RuleFor(c => c.Cpf)
                .NotEmpty().WithMessage("O CPF é obrigatório.")
                .Length(11).WithMessage("O CPF deve ter 11 caracteres.")
                .Matches(@"^\d{11}$").WithMessage("O CPF deve conter apenas números.");

            RuleFor(c => c.Email)
                .NotEmpty().WithMessage("O e-mail é obrigatório.")
                .EmailAddress().WithMessage("O e-mail informado não é válido.");

            RuleFor(c => c.Telefone)
                .MaximumLength(20).WithMessage("O telefone deve ter no máximo 20 caracteres.")
                .When(c => !string.IsNullOrEmpty(c.Telefone));

            RuleFor(c => c.Endereco)
                .NotNull().WithMessage("O endereço é obrigatório.")
                .SetValidator(new EnderecoValidator());
        }
    }

    public class EnderecoValidator : AbstractValidator<Endereco>
    {
        public EnderecoValidator()
        {
            RuleFor(e => e.Logradouro)
                .NotEmpty().WithMessage("O logradouro é obrigatório.");

            RuleFor(e => e.Numero)
                .NotEmpty().WithMessage("O número é obrigatório.");

            RuleFor(e => e.Cidade)
                .NotEmpty().WithMessage("A cidade é obrigatória.");

            RuleFor(e => e.Estado)
                .NotEmpty().WithMessage("O estado é obrigatório.");

            RuleFor(e => e.Cep)
                .NotEmpty().WithMessage("O CEP é obrigatório.")
                .Matches(@"^\d{8}$").WithMessage("O CEP deve conter 8 dígitos numéricos.");
        }
    }
}
