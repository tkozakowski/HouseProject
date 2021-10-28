using Application.Core;
using MediatR;

namespace Application.LoanTranches.Command.Remove
{
    public class RemoveLoanTrancheCommand: IRequest<Result<Unit>>
    {
        public int Id { get; set; }
    }
}
