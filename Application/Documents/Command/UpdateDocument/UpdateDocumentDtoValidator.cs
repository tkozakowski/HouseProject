using FluentValidation;

namespace Application.Documents.Command.UpdateDocument
{
    public class UpdateDocumentDtoValidator : AbstractValidator<UpdateDocumentDto>
    {
        public UpdateDocumentDtoValidator()
        {
            RuleFor(x => x.Name).NotEmpty().WithMessage("Name cannot be empty");
            RuleFor(x => x.Name).MaximumLength(100).WithMessage("Max name length 100");
            RuleFor(x => x.Cost).Custom((x, context) =>
            {
                if (!(int.TryParse(x, out int value)) || value < 0)
                {
                    context.AddFailure($"{x} for Cost is not a valid number or less than 0");
                }
            });
            RuleFor(x => x.StageId).GreaterThan(0);
            RuleFor(x => x.PostId).GreaterThan(0);
        }
    }
}
