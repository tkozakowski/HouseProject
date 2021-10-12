using Application.Documents.Command.InsertDocument;
using FluentValidation;

namespace Application.Validators
{
    public class CreateDocumentDtoValidator : AbstractValidator<CreateDocumentDto>
    {
        public CreateDocumentDtoValidator()
        {
            RuleFor(x => x.Name).MaximumLength(100).WithMessage("Name has max length 100");
            RuleFor(x => x.Name).NotEmpty().WithMessage("Name can not be empty");
            RuleFor(x => x.Cost).Custom((x, context) => 
            {
                if(!(int.TryParse(x, out int value))|| value < 0)
                {
                    context.AddFailure($"{x} for Cost is not a valid number or less than 0");
                }
            });
            RuleFor(x => x.StageId).GreaterThan(0);
            RuleFor(x => x.PostId).GreaterThan(0);
        }
    }
}
