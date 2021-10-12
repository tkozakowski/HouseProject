using Application.Core;
using Application.Dto.LoanTranche;
using MediatR;

namespace Application.LoanTranches.Query.GetDetail
{
    public class GetLoanTrancheByIdQuery: IRequest<Response<LoanTrancheDto>>
    {
        public int Id { get; set; }
    }
}
