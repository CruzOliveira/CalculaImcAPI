using Domain.Entities;
using FluentValidation;

namespace Services.Validators
{
    public class CriadorUserValidator : AbstractValidator<CriadorUser>
    {
        public CriadorUserValidator()
        {
            ////EXEMPLO
            //RuleFor(c => c.Login)
            //      .NotEmpty()
            //      .WithMessage("Login n�o pode ser nulo.");
        }
    }
}
