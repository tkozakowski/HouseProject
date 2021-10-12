using Application.Core;
using MediatR;

namespace Application.LoanTranches.Command.Remove
{
    public class RemoveLoanTrancheCommand: IRequest<Response<Unit>>
    {
        public int Id { get; set; }
    }
}
