using Application.Core;
using MediatR;
using System.Collections.Generic;

namespace Application.Executions.Query.GetAll
{
    public class GetExecutionsQuery: IRequest<Result<IEnumerable<GetExecutionsDto>>>
    {
    }
}
