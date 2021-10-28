using Application.Core;
using MediatR;

namespace Application.Projects.Command.CreateProject
{
    public class CreateProjectCommand: IRequest<Result<Unit>>
    {
        public CreateProjectDto CreateProjectDto { get; set; }
    }
}
