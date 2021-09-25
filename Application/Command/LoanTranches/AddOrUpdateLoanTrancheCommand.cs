using Application.Core;
using Domain.Entities;
using MediatR;

namespace Application.Command.LoanTranches
{
    public class AddOrUpdateLoanTrancheCommand : IRequest<Response<Unit>>
    {
        public LoanTranche LoanTranche { get; set; }
    }
}
