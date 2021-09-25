using Application.Command.LoanTranches;
using Application.Core;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Threading;
using System.Threading.Tasks;
using Application.Interfaces;

namespace Application.Handlers.LoanTranches
{
    public class RemoveLoanTrancheHandler : IRequestHandler<RemoveLoanTrancheCommand, Response<Unit>>
    {
        private readonly IHouseProjectDbContext _houseProjectDbContext;
        public RemoveLoanTrancheHandler(IHouseProjectDbContext houseProjectDbContext)
        {
            _houseProjectDbContext = houseProjectDbContext;
        }
        public async Task<Response<Unit>> Handle(RemoveLoanTrancheCommand request, CancellationToken cancellationToken)
        {
            var result = await _houseProjectDbContext.LoanTranches.FirstOrDefaultAsync(x => x.Id == request.Id);

            if (result is null) return Response<Unit>.Failure("Failed to remove loan tranche");

            _houseProjectDbContext.LoanTranches.Remove(result);

            var success = await _houseProjectDbContext.SaveChangesAsync() > 0;

            if (!success) return Response<Unit>.Failure("Failed to remove loan tranche");

            return Response<Unit>.Success(Unit.Value);
        }
    }
}
