using Application.Core;
using Application.Dto.LoanTranche;
using MediatR;

namespace Application.Queries.LoanTranches
{
    public class GetLoanTrancheByIdQuery: IRequest<Response<LoanTrancheDto>>
    {
        public int Id { get; set; }
    }
}
