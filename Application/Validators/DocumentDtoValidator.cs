using FluentValidation;
using Application.Dto;

namespace Application.Validators
{
    public class DocumentDtoValidator : AbstractValidator<DocumentDto>
    {
        public DocumentDtoValidator()
        {
            RuleFor(x => x.Name).NotEmpty().WithMessage("Document can not have an empty name");
            RuleFor(x => x.Name).MaximumLength(100).WithMessage("Document name must be between 0 and 100 characters long");
            RuleFor(x => x.Cost).Custom((x, context) =>
            {
                if (!(int.TryParse(x, out int value)) || value < 0)
                {
                    context.AddFailure($"{x} is not a valid number or less than 0");
                }
            });
        }
    }
}
