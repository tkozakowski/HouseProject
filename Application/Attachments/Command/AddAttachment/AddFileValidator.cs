using FluentValidation;

namespace Application.Attachments.Command.AddAttachment
{
    public class AddFileValidator: AbstractValidator<AddFileDto>
    {
        public AddFileValidator()
        {
            RuleFor(x => x.Name).NotEmpty().WithMessage("Name cannot be empty");
            RuleFor(x => x.Name).MaximumLength(100).WithMessage("Max name length 100");
        }
    }
}
