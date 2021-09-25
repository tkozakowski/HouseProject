using Application.Core;
using MediatR;

namespace Application.Command.LoanTranches
{
    public class RemoveLoanTrancheCommand: IRequest<Response<Unit>>
    {
        public int Id { get; set; }
    }
}
