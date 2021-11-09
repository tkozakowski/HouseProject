using FluentValidation;

namespace Application.Executions.Command.Add
{
    public class AddExecutionValidator : AbstractValidator<AddExecutionDto>
    {
        public AddExecutionValidator()
        {
            RuleFor(x => x.Name).NotEmpty().WithMessage("Name cannot be empty");
            RuleFor(x => x.EstimatedCost).Custom((x, validationContext) =>
            {
                if (!decimal.TryParse(x, out decimal value) || value < 0)
                {
                    validationContext.AddFailure($"{x} for estimated cost is not a valid number or is less than 0");
                }
            });
            RuleFor(x => x.LaborCost).Custom((x, validationContext) => 
            {
                if(!decimal.TryParse(x , out decimal value) || value < 0)
                {
                    validationContext.AddFailure($"{x} for labor cost is not a valid number or is less than 0");
                }
            });           
            RuleFor(x => x.CostPayed).Custom((x, validationContext) => 
            {
                if(!decimal.TryParse(x , out decimal value) || value < 0)
                {
                    validationContext.AddFailure($"{x} for payed cost is not a valid number or is less than 0");
                }
            });

        }
    }
}
