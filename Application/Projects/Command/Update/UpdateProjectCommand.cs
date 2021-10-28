using Application.Core;
using MediatR;

namespace Application.Projects.Command.Update
{
    public class UpdateProjectCommand: IRequest<Result<Unit>>
    {
        public UpdateProjectDto UpdateProjectDto { get; set; }
    }
}
