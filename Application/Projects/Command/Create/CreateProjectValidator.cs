using FluentValidation;

namespace Application.Projects.Command.CreateProject
{
    public class CreateProjectValidator: AbstractValidator<CreateProjectDto>
    {
        public CreateProjectValidator()
        {
            RuleFor(x => x.Name).NotEmpty().WithMessage("Name cannot be empty");
            RuleFor(x => x.Name).MaximumLength(100).WithMessage("Name max length is 100 digit");
        }
    }
}
