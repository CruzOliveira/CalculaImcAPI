using Domain.Entities;
using FluentValidation;

namespace Services.Validators
{
    public class AlterarPesoAlturaValidator : AbstractValidator<AlterarPesoAltura>
    {
        public AlterarPesoAlturaValidator()
        {
            ////EXEMPLO
            //RuleFor(c => c.Login)
            //      .NotEmpty()
            //      .WithMessage("Login não pode ser nulo.");
        }
    }
}
