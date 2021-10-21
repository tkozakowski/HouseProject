using FluentValidation;

namespace Application.CosmosDocuments.Command.Update
{
    public class UpdateCosmosDocumentValidator: AbstractValidator<UpdateCosmosDocumentDto>
    {
        public UpdateCosmosDocumentValidator()
        {
            RuleFor(x => x.Name).NotEmpty().WithMessage("Name cannot be emtpy");
            RuleFor(x => x.Name).MaximumLength(100).WithMessage("Name max length 100");
            RuleFor(x => x.UserId).NotNull();
        }
    }
}
