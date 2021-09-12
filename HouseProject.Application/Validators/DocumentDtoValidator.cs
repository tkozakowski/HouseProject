using FluentValidation;
using HouseProject.Application.Dto;

namespace HouseProject.Application.Validators
{
    public class DocumentDtoValidator : AbstractValidator<DocumentDto>
    {
        public DocumentDtoValidator()
        {
            RuleFor(x => x.Name).NotEmpty();
        }
    }
}
