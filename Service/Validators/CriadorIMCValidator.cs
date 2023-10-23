using Domain.Entities;
using FluentValidation;

namespace Services.Validators
{
    public class CriadorIMCValidator : AbstractValidator<CriadorIMC>
    {
        public CriadorIMCValidator()
        {
            ////EXEMPLO
            //RuleFor(c => c.Login)
            //      .NotEmpty()
            //      .WithMessage("Login não pode ser nulo.");
        }
    }
}
