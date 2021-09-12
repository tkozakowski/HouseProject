using HouseProject.Application.Core;
using HouseProject.Application.Queries.LoanTranches;
using HouseProject.Domain.Entities;
using HouseProject.Persistence;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace HouseProject.Application.Handlers.LoanTranches
{
    public class GetAllLoanTranchesHandler : IRequestHandler<GetAllLoanTranchesQuery, Result<List<LoanTranche>>>
    {
        private readonly HouseProjectDbContext _houseProjectDbContext;
        public GetAllLoanTranchesHandler(HouseProjectDbContext houseProjectDbContext)
        {
            _houseProjectDbContext = houseProjectDbContext;
        }
        public async Task<Result<List<LoanTranche>>> Handle(GetAllLoanTranchesQuery request, CancellationToken cancellationToken)
        {
            return Result<List<LoanTranche>>.Success(await _houseProjectDbContext.LoanTranches.ToListAsync());
        }
    }
}
