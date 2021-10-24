using Application.Core;
using MediatR;
using System.Threading;
using System.Threading.Tasks;
using Domain.Interfaces;

namespace Application.LoanTranches.Command.Remove
{
    //    public class RemoveLoanTrancheHandler : IRequestHandler<RemoveLoanTrancheCommand, Response<Unit>>
    //    {
    //        private readonly ILoanTrancheRepository _loanTrancheRepository;

    //        public RemoveLoanTrancheHandler(ILoanTrancheRepository loanTrancheRepository)
    //        {
    //            _loanTrancheRepository = loanTrancheRepository;
    //        }

    //        public async Task<Response<Unit>> Handle(RemoveLoanTrancheCommand request, CancellationToken cancellationToken)
    //        {
    //            var result = await _loanTrancheRepository.GetByIdAsync(request.Id);

    //            if (result is null) return Response<Unit>.Failure("Failed to remove loan tranche");          

    //            var success = await _loanTrancheRepository.DeleteAsync(result);

    //            if (!success) return Response<Unit>.Failure("Failed to remove loan tranche");

    //            return Response<Unit>.Success(Unit.Value);
    //        }
    //    }
}
