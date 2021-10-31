using FluentValidation;

namespace Application.Materials.Command.Add
{
    public class AddMaterialValidator: AbstractValidator<AddMaterialDto>
    {
        public AddMaterialValidator()
        {
            RuleFor(x => x.Name).NotEmpty().WithMessage("Name cannot by empty");
            RuleFor(x => x.Amount).GreaterThanOrEqualTo(0).WithMessage("Amount shoult by greater or equal 0");
            RuleFor(x => x.PriceItem).Custom((x, content) => 
            {
                if(!decimal.TryParse(x, out decimal value) || value < 0)
                {
                    content.AddFailure($"{x} for price is not a valid number or less than 0");
                }
            });
        }
    }
}
