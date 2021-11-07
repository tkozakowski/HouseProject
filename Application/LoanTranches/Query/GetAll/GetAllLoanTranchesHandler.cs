using Application.Core;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Application.Dto.LoanTranche.Query;
using AutoMapper;
using Application.Interfaces;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;

namespace Application.LoanTranches.Query.GetAll
{
    public record GetAllLoanTranchesHandler : IRequestHandler<GetAllLoanTranchesQuery, Result<IEnumerable<LoanTrancheDto>>>
    {
        private readonly IHouseProjectDbContext _houseProjectDbContext;
        private readonly IMapper _mapper;

        public GetAllLoanTranchesHandler(IHouseProjectDbContext houseProjectDbContext, IMapper mapper)
        {
            _houseProjectDbContext = houseProjectDbContext;
            _mapper = mapper;
        }

        public async Task<Result<IEnumerable<LoanTrancheDto>>> Handle(GetAllLoanTranchesQuery request, CancellationToken cancellationToken)
        {
            var result = await _houseProjectDbContext.LoanTranches.ProjectTo<LoanTrancheDto>(_mapper.ConfigurationProvider).ToListAsync();

            if (result != null) return Result<IEnumerable<LoanTrancheDto>>.Success(result);

            return Result<IEnumerable<LoanTrancheDto>>.Failure("Failed to get loan tranches");
        }
    }
}
