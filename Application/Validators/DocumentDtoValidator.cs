using FluentValidation;
using Application.Dto;

namespace Application.Validators
{
    public class DocumentDtoValidator : AbstractValidator<DocumentDto>
    {
        public DocumentDtoValidator()
        {
            RuleFor(x => x.Name).NotEmpty().WithMessage("Document can not have an empty name");
            RuleFor(x => x.Name).Length(100).WithMessage("Document name must be between 0 and 100 characters long");
        }
    }
}
