using Application.Core;
using MediatR;

namespace Application.Command.LoanTranches
{
    public class RemoveLoanTrancheCommand: IRequest<Result<Unit>>
    {
        public int Id { get; set; }
    }
}
