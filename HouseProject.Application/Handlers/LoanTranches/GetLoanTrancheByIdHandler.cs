using Application.Core;
using Application.Queries.LoanTranches;
using Domain.Entities;
using Infrastructure.Persistence;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Handlers.LoanTranches
{
    public class GetLoanTrancheByIdHandler : IRequestHandler<GetLoanTrancheByIdQuery, Result<LoanTranche>>
    {
        private readonly HouseProjectDbContext _houseProjectDbContext;

        public GetLoanTrancheByIdHandler(HouseProjectDbContext houseProjectDbContext)
        {
            _houseProjectDbContext = houseProjectDbContext;
        }
        public async Task<Result<LoanTranche>> Handle(GetLoanTrancheByIdQuery request, CancellationToken cancellationToken)
        {
            var result = await _houseProjectDbContext.LoanTranches.FirstOrDefaultAsync(x => x.Id == request.Id);

            if (result is null) return Result<LoanTranche>.Failure("Failed to get loan tranche");

            return Result<LoanTranche>.Success(result);
        }
    }
}
