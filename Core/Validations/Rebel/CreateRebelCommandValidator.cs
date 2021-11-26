using Domain.Commands.Rebel;
using FluentValidation;

namespace Core.Validations.Rebel
{
    public class CreateRebelCommandValidator : AbstractValidator<CreateRebelCommand>
    {
        public CreateRebelCommandValidator()
        {
            RuleFor(x => x.Name)
                .NotEmpty().WithMessage("Campo obrigatório!");
            RuleFor(x => x.Gender)
                .NotNull().WithMessage("Campo obrigatório!");
            RuleFor(x => x.GalaxyName)
                .NotEmpty().WithMessage("Campo obrigatório!");
            RuleForEach(x => x.InventoryItems).NotEmpty().WithMessage("Informe o inventário")
                .ChildRules(orders =>
                {
                    orders.RuleFor(x => x.ItemId).GreaterThan(0).WithMessage("Campo obrigatório");
                    orders.RuleFor(x => x.Count).GreaterThan(0).WithMessage("Campo obrigatório");
                });
        }
    }
}
