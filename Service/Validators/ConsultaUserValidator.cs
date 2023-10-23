using Domain.Entities;
using FluentValidation;

namespace Services.Validators
{
    public class ConsultaUserValidator : AbstractValidator<ConsultaUser>
    {
        public ConsultaUserValidator()
        {
            ////EXEMPLO
            //RuleFor(c => c.Login)
            //      .NotEmpty()
            //      .WithMessage("Login n�o pode ser nulo.");
        }
    }
}
