using Application.Core;
using Application.Interfaces;
using Application.Queries.LoanTranches;
using Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Handlers.LoanTranches
{
    public class GetLoanTrancheByIdHandler : IRequestHandler<GetLoanTrancheByIdQuery, Response<LoanTranche>>
    {
        private readonly IHouseProjectDbContext _houseProjectDbContext;

        public GetLoanTrancheByIdHandler(IHouseProjectDbContext houseProjectDbContext)
        {
            _houseProjectDbContext = houseProjectDbContext;
        }
        public async Task<Response<LoanTranche>> Handle(GetLoanTrancheByIdQuery request, CancellationToken cancellationToken)
        {
            var result = await _houseProjectDbContext.LoanTranches.FirstOrDefaultAsync(x => x.Id == request.Id);

            if (result is null) return Response<LoanTranche>.Failure("Failed to get loan tranche");

            return Response<LoanTranche>.Success(result);
        }
    }
}
