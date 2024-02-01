using FluentValidation;
using WebApi.Models;

namespace WebApi.Validators;

public class UsuarioValidator : AbstractValidator<UsuarioModel>
{
    public UsuarioValidator()
    {
        RuleFor(UsuarioModel => UsuarioModel.Nome)
            .NotEmpty().WithMessage("O nome é obrigatório.")
            .Length(2, 150).WithMessage("O nome deve ter entre 2 e 150 caracteres.");

        RuleFor(UsuarioModel => UsuarioModel.Email)
            .NotEmpty().WithMessage("O e-mail é obrigatório.")
            .EmailAddress().WithMessage("O e-mail não é válido.");

        RuleFor(UsuarioModel => UsuarioModel.Idade)
            .InclusiveBetween(18, 99).WithMessage("A idade do usuário deve ser entre 18 e 99 anos.");
    }
}