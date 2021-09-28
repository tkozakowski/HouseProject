using Application.Dto.Materials;
using FluentValidation;

namespace Application.Validators
{
    public class GetMaterialsDtoValidator : AbstractValidator<GetMaterialsDto>
    {
        public GetMaterialsDtoValidator()
        {
            RuleFor(x => x.Name).NotEmpty();
         }
    }
}
