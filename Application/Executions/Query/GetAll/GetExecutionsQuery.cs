using MediatR;
using System.Collections.Generic;

namespace Application.Executions.Query.GetAll
{
    public class GetExecutionsQuery: IRequest<IEnumerable<GetExecutionsDto>>
    {
    }
}
