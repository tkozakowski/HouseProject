using Application.Core;
using Application.Dto.LoanTranche;
using MediatR;

namespace Application.LoanTranches.Command.Add
{
    public class AddOrUpdateLoanTrancheCommand : IRequest<Result<Unit>>
    {
        public LoanTrancheDto LoanTrancheDto { get; set; }
    }
}
