using Application.Core;
using MediatR;
using System.Collections.Generic;

namespace Application.Preparations.Query.GetAll
{
    public record GetPreparationsQuery: IRequest<Result<IEnumerable<GetPreparationsDto>>>
    {
    }
}
