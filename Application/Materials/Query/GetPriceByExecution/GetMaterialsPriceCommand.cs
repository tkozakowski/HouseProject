using MediatR;

namespace Application.Materials.Query.GetPriceByExecution
{
    public record GetMaterialsPriceCommand(int executionId): IRequest<GetMaterialsPriceDto>
    {
    }
}
