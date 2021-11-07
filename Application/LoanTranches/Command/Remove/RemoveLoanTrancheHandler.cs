using Application.Core;
using MediatR;
using System.Threading;
using System.Threading.Tasks;
using Application.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Application.LoanTranches.Command.Remove
{
    public class RemoveLoanTrancheHandler : IRequestHandler<RemoveLoanTrancheCommand, Result<Unit>>
    {
        private readonly IHouseProjectDbContext _houseProjectDbContext;

        public RemoveLoanTrancheHandler(IHouseProjectDbContext houseProjectDbContext)
        {
            _houseProjectDbContext = houseProjectDbContext;
        }

        public async Task<Result<Unit>> Handle(RemoveLoanTrancheCommand request, CancellationToken cancellationToken)
        {
            var loanTranche = await _houseProjectDbContext.LoanTranches.FirstOrDefaultAsync(x => x.Id == request.Id);

            if (loanTranche is null) return Result<Unit>.Failure($"Failed to remove loan tranche wit id {request.Id}");

            _houseProjectDbContext.LoanTranches.Remove(loanTranche);

            await _houseProjectDbContext.SaveChangesAsync();

            return Result<Unit>.Success(Unit.Value);
        }
    }
}
