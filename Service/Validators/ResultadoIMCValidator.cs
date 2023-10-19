using Domain.Entities;
using FluentValidation;

namespace Services.Validators
{
    public class ResultadoIMCValidator : AbstractValidator<ResultadoIMC>
    {
        public ResultadoIMCValidator()
        {
            ////EXEMPLO
            //RuleFor(c => c.Login)
            //      .NotEmpty()
            //      .WithMessage("Login não pode ser nulo.");
        }
    }
}
