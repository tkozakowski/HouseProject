using Application.Core;
using Application.Dto.LoanTranche;
using MediatR;

namespace Application.Command.LoanTranches
{
    public class AddOrUpdateLoanTrancheCommand : IRequest<Response<Unit>>
    {
        public LoanTrancheDto LoanTrancheDto { get; set; }
    }
}
