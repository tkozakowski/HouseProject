using HouseProject.Application.Core;
using HouseProject.Application.Queries.LoanTranches;
using HouseProject.Persistence;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Threading;
using System.Threading.Tasks;

namespace HouseProject.Application.Handlers.LoanTranches
{
    public class GetLoanTrancheByIdHandler : IRequestHandler<GetLoanTrancheByIdQuery, Result<decimal>>
    {
        private readonly HouseProjectDbContext _houseProjectDbContext;

        public GetLoanTrancheByIdHandler(HouseProjectDbContext houseProjectDbContext)
        {
            _houseProjectDbContext = houseProjectDbContext;
        }
        public async Task<Result<decimal>> Handle(GetLoanTrancheByIdQuery request, CancellationToken cancellationToken)
        {
            return (await _houseProjectDbContext.LoanTranches.FirstOrDefaultAsync(x => x.Id == request.Id)).Amount;
        }
    }
}
