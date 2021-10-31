using Application.Core;
using MediatR;

namespace Application.Materials.Query.GetDetail
{
    public record GetMaterialDetailQuery(int id): IRequest<Result<GetMaterialDto>>
    {
    }
}
