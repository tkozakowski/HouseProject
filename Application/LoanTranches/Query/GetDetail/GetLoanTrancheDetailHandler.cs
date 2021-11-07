using Application.Core;
using Application.Dto.LoanTranche.Query;
using Application.Interfaces;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Application.LoanTranches.Query.GetDetail
{
    public class GetLoanTrancheDetailHandler : IRequestHandler<GetLoanTrancheByIdQuery, Result<LoanTrancheDto>>
    {
        private readonly IHouseProjectDbContext _houseProjectDbContext;
        private readonly IMapper _mapper;

        public GetLoanTrancheDetailHandler(IHouseProjectDbContext houseProjectDbContext, IMapper mapper)
        {
            _houseProjectDbContext = houseProjectDbContext;
            _mapper = mapper;
        }

        public async Task<Result<LoanTrancheDto>> Handle(GetLoanTrancheByIdQuery request, CancellationToken cancellationToken)
        {
            var result = await _houseProjectDbContext.LoanTranches.Where(x => x.Id == request.Id).ProjectTo<LoanTrancheDto>(_mapper.ConfigurationProvider).FirstOrDefaultAsync();

            if (result is null) return Result<LoanTrancheDto>.Failure("Failed to get loan tranche");
           
            return Result<LoanTrancheDto>.Success(result);
        }
    }
}
