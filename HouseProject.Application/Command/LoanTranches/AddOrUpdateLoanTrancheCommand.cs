using HouseProject.Application.Core;
using HouseProject.Domain.Entities;
using MediatR;

namespace HouseProject.Application.Command.LoanTranches
{
    public class AddOrUpdateLoanTrancheCommand : IRequest<Result<Unit>>
    {
        public LoanTranche LoanTranche { get; set; }
    }
}
