using Application.Core;
using MediatR;

namespace Application.LoanTranches.Command.Add
{
    public class AddLoanTrancheCommand : IRequest<Result<Unit>>
    {
        public string Stage { get; set; }
        public decimal Amount { get; set; }
    }
}
