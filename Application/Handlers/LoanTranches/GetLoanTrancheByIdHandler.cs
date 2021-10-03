using Application.Core;
using Application.Queries.LoanTranches;
using Domain.Entities;
using Domain.Interfaces;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Handlers.LoanTranches
{
    public class GetLoanTrancheByIdHandler : IRequestHandler<GetLoanTrancheByIdQuery, Response<LoanTranche>>
    {
        private readonly ILoanTrancheRepository _loanTrancheRepository;

        public GetLoanTrancheByIdHandler(ILoanTrancheRepository loanTrancheRepository)
        {
            _loanTrancheRepository = loanTrancheRepository;
        }

        public async Task<Response<LoanTranche>> Handle(GetLoanTrancheByIdQuery request, CancellationToken cancellationToken)
        {
            var result = await _loanTrancheRepository.GetByIdAsync(request.Id);

            if (result is null) return Response<LoanTranche>.Failure("Failed to get loan tranche");

            return Response<LoanTranche>.Success(result);
        }
    }
}
