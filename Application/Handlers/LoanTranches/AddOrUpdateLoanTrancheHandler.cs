using Application.Command.LoanTranches;
using Application.Core;
using Domain.Interfaces;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Handlers.LoanTranches
{
    public class AddOrUpdateLoanTrancheHandler : IRequestHandler<AddOrUpdateLoanTrancheCommand, Response<Unit>>
    {
        private readonly ILoanTrancheRepository _loanTrancheHandlerRepository;

        public AddOrUpdateLoanTrancheHandler(ILoanTrancheRepository loanTrancheHandlerRepository)
        {
            _loanTrancheHandlerRepository = loanTrancheHandlerRepository;
        }

        public async Task<Response<Unit>> Handle(AddOrUpdateLoanTrancheCommand request, CancellationToken cancellationToken)
        {
            var loanTranche = await _loanTrancheHandlerRepository.GetAsync(request.LoanTranche.Stage);

            if (loanTranche is null)
            {
                var addSuccess = await _loanTrancheHandlerRepository.AddAsync(request.LoanTranche);
                
                if (!addSuccess) return Response<Unit>.Failure("Failed to add new loan tranche");

                return Response<Unit>.Success(Unit.Value);
            }

            loanTranche.Amount = request.LoanTranche.Amount;

            var updateSuccess = await _loanTrancheHandlerRepository.UpdateAsync(loanTranche); 

            if (!updateSuccess) return Response<Unit>.Failure("Failed to update loan tranche");

            return Response<Unit>.Success(Unit.Value);
        }
    }
}
