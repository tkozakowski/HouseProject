using Application.Core;
using Application.Queries.LoanTranches;
using Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Application.Interfaces;

namespace Application.Handlers.LoanTranches
{
    public class GetAllLoanTranchesHandler : IRequestHandler<GetAllLoanTranchesQuery, Result<List<LoanTranche>>>
    {
        private readonly IHouseProjectDbContext _houseProjectDbContext;
        public GetAllLoanTranchesHandler(IHouseProjectDbContext houseProjectDbContext)
        {
            _houseProjectDbContext = houseProjectDbContext;
        }
        public async Task<Result<List<LoanTranche>>> Handle(GetAllLoanTranchesQuery request, CancellationToken cancellationToken)
        {
            return Result<List<LoanTranche>>.Success(await _houseProjectDbContext.LoanTranches.ToListAsync());
        }
    }
}
