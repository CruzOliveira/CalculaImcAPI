using Domain.Entities;
using FluentValidation;

namespace Services.Validators
{
    public class ExcluirUsuarioValidator : AbstractValidator<ExcluirUsuario>
    {
        public ExcluirUsuarioValidator()
        {
            ////EXEMPLO
            //RuleFor(c => c.Login)
            //      .NotEmpty()
            //      .WithMessage("Login n�o pode ser nulo.");
        }
    }
}
