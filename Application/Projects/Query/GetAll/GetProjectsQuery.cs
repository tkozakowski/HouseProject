using Application.Core;
using MediatR;
using System.Collections.Generic;

namespace Application.Projects.Query.GetAll
{
    public record GetProjectsQuery: IRequest<Result<IEnumerable<GetProjectDto>>>
    {
    }
}
