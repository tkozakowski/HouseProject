using Application.Core;
using Application.Dto.LoanTranche.Query;
using MediatR;

namespace Application.LoanTranches.Query.GetDetail
{
    public record GetLoanTrancheByIdQuery: IRequest<Result<LoanTrancheDto>>
    {
        public int Id { get; set; }
    }
}
