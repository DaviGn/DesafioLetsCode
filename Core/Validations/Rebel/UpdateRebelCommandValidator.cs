using Domain.Commands.Rebel;
using FluentValidation;

namespace Core.Validations.Rebel
{
    public class UpdateRebelCommandValidator : AbstractValidator<UpdateRebelCommand>
    {
        public UpdateRebelCommandValidator()
        {
            RuleFor(x => x.GalaxyName)
                .NotEmpty().WithMessage("Campo obrigatório!");
        }
    }
}
