using FluentValidation;
using Application.Dto;

namespace Application.Validators
{
    public class DocumentDtoValidator : AbstractValidator<DocumentDto>
    {
        public DocumentDtoValidator()
        {
            RuleFor(x => x.Name).NotEmpty();
        }
    }
}
