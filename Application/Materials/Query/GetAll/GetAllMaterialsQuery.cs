using Application.Core;
using MediatR;
using System.Collections.Generic;

namespace Application.Materials.Query.GetAll
{
    public record GetAllMaterialsQuery: IRequest<Result<IEnumerable<GetMaterialsDto>>>
    {
    }
}
