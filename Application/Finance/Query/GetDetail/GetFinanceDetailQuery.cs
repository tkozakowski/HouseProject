using Application.Core;
using MediatR;

namespace Application.Finance.Query.GetDetail
{
    public record GetFinanceDetailQuery: IRequest<Result<GetFinanceDto>>
    {
    }
}
