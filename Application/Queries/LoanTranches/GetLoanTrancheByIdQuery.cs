using Application.Core;
using Domain.Entities;
using MediatR;

namespace Application.Queries.LoanTranches
{
    public class GetLoanTrancheByIdQuery: IRequest<Result<LoanTranche>>
    {
        public int Id { get; set; }
    }
}
