using Domain.Commands.RebelInventory;
using FluentValidation;

namespace Core.Validations.RebelInventory
{
    public class RebelInventoryExchangeCommandValidator : AbstractValidator<RebelInventoryExchangeCommand>
    {
        public RebelInventoryExchangeCommandValidator()
        {
            RuleFor(x => x.FirstRebelId).NotEmpty().WithMessage("Informe o primeiro Rebelde")
                    .GreaterThan(0).WithMessage("Informe o primeiro Rebelde");
            RuleFor(x => x.SecondRebelId).NotEmpty().WithMessage("Informe o primeiro Rebelde")
                .GreaterThan(0).WithMessage("Informe o segundo Rebelde");
            RuleForEach(x => x.FirstRebelItems)
                .NotEmpty().WithMessage("Informe os itens!")
                .ChildRules(items =>
                {
                    items.RuleFor(y => y.ItemId).GreaterThan(0).WithMessage("Informe o Item!");
                    items.RuleFor(y => y.Count).GreaterThan(0).WithMessage("Quantidade obrigatória!");
                });
            RuleForEach(x => x.SecondRebelItems)
                .NotEmpty().WithMessage("Informe os itens!")
                .ChildRules(items =>
                {
                    items.RuleFor(y => y.ItemId).GreaterThan(0).WithMessage("Informe o Item!");
                    items.RuleFor(y => y.Count).GreaterThan(0).WithMessage("Quantidade obrigatória!");
                });
        }
    }
}
