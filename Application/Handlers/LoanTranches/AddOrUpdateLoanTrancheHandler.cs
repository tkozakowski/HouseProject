using Application.Command.LoanTranches;
using Application.Core;
using Application.Interfaces;
using MediatR;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Handlers.LoanTranches
{
    public class AddOrUpdateLoanTrancheHandler : IRequestHandler<AddOrUpdateLoanTrancheCommand, Result<Unit>>
    {
        private readonly IHouseProjectDbContext _houseProjectDbContext;

        public AddOrUpdateLoanTrancheHandler(IHouseProjectDbContext houseProjectDbContext)
        {
            _houseProjectDbContext = houseProjectDbContext;
        }
        public async Task<Result<Unit>> Handle(AddOrUpdateLoanTrancheCommand request, CancellationToken cancellationToken)
        {
            var loanTranche = _houseProjectDbContext.LoanTranches.FirstOrDefault(x => x.Stage == request.LoanTranche.Stage);

            if (loanTranche is null)
            {
                _houseProjectDbContext.LoanTranches.Add(request.LoanTranche);
                
                var addSuccess = await _houseProjectDbContext.SaveChangesAsync() > 0;

                if (!addSuccess) return Result<Unit>.Failure("Failed to add new loan tranche");

                return Result<Unit>.Success(Unit.Value);
            }

            loanTranche.Amount = request.LoanTranche.Amount;

            var success = await _houseProjectDbContext.SaveChangesAsync() > 0;

            if (!success) return Result<Unit>.Failure("Failed to update loan tranche");

            return Result<Unit>.Success(Unit.Value);
        }
    }
}
