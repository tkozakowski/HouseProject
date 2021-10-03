using Application.Core;
using Application.Queries.LoanTranches;
using Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Application.Interfaces;
using Domain.Interfaces;

namespace Application.Handlers.LoanTranches
{
    public class GetAllLoanTranchesHandler : IRequestHandler<GetAllLoanTranchesQuery, Response<List<LoanTranche>>>
    {
        private readonly ILoanTrancheRepository _loanTrancheRepository;

        public GetAllLoanTranchesHandler(ILoanTrancheRepository loanTrancheRepository)
        {
            _loanTrancheRepository = loanTrancheRepository;
        }

        public async Task<Response<List<LoanTranche>>> Handle(GetAllLoanTranchesQuery request, CancellationToken cancellationToken)
        {
            var loanTranches = await _loanTrancheRepository.GetAllAsync();

            return Response<List<LoanTranche>>.Success(loanTranches);
        }
    }
}
