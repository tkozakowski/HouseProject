using Application.Command.LoanTranches;
using Application.Core;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Threading;
using System.Threading.Tasks;
using Infrastructure.Persistence;

namespace Application.Handlers.LoanTranches
{
    public class RemoveLoanTrancheHandler : IRequestHandler<RemoveLoanTrancheCommand, Result<Unit>>
    {
        private readonly HouseProjectDbContext _houseProjectDbContext;
        public RemoveLoanTrancheHandler(HouseProjectDbContext houseProjectDbContext)
        {
            _houseProjectDbContext = houseProjectDbContext;
        }
        public async Task<Result<Unit>> Handle(RemoveLoanTrancheCommand request, CancellationToken cancellationToken)
        {
            var result = await _houseProjectDbContext.LoanTranches.FirstOrDefaultAsync(x => x.Id == request.Id);

            if (result is null) return Result<Unit>.Failure("Failed to remove loan tranche");

            _houseProjectDbContext.LoanTranches.Remove(result);

            var success = await _houseProjectDbContext.SaveChangesAsync() > 0;

            if (!success) return Result<Unit>.Failure("Failed to remove loan tranche");

            return Result<Unit>.Success(Unit.Value);
        }
    }
}
