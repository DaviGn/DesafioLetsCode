using Domain.Commands.Rebel;
using FluentValidation;

namespace Core.Validations.Rebel
{
    public class ReportBetrayalRebelCommandValidator : AbstractValidator<ReportBetrayalRebelCommand>
    {
        public ReportBetrayalRebelCommandValidator()
        {
            RuleFor(x => x.RebelId)
                .NotEmpty().WithMessage("Informe o rebelde!")
                .GreaterThan(0).WithMessage("Informe o rebelde!");
        }
    }
}
