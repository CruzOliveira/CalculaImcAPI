using Domain.Entities;
using FluentValidation;

namespace Services.Validators
{
    public class AlterarSenhaValidator : AbstractValidator<AlterarSenha>
    {
        public AlterarSenhaValidator()
        {
            ////EXEMPLO
            //RuleFor(c => c.Login)
            //      .NotEmpty()
            //      .WithMessage("Login não pode ser nulo.");
        }
    }
}
