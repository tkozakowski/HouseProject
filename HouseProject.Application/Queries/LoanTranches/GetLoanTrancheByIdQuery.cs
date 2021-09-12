using HouseProject.Application.Core;
using MediatR;

namespace HouseProject.Application.Queries.LoanTranches
{
    public class GetLoanTrancheByIdQuery: IRequest<Result<decimal>>
    {
        public int Id { get; set; }
    }
}
