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
    public class GetAllLoanTranchesHandler : IRequestHandler<GetAllLoanTranchesQuery, Response<List<LoanTranche>>>
    {
        private readonly IHouseProjectDbContext _houseProjectDbContext;
        public GetAllLoanTranchesHandler(IHouseProjectDbContext houseProjectDbContext)
        {
            _houseProjectDbContext = houseProjectDbContext;
        }
        public async Task<Response<List<LoanTranche>>> Handle(GetAllLoanTranchesQuery request, CancellationToken cancellationToken)
        {
            return Response<List<LoanTranche>>.Success(await _houseProjectDbContext.LoanTranches.ToListAsync());
        }
    }
}
