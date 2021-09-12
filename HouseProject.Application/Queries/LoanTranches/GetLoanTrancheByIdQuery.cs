using HouseProject.Application.Core;
using HouseProject.Domain.Entities;
using MediatR;

namespace HouseProject.Application.Queries.LoanTranches
{
    public class GetLoanTrancheByIdQuery: IRequest<Result<LoanTranche>>
    {
        public int Id { get; set; }
    }
}
