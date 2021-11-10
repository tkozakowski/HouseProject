using Application.Core;
using Application.Interfaces;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Finance.Query.GetDetail
{
    public class GetFinanceDetailHandler : IRequestHandler<GetFinanceDetailQuery, Result<GetFinanceDto>>
    {
        private readonly IHouseProjectDbContext _houseProjectDbContext;
        private readonly IMapper _mapper;

        public GetFinanceDetailHandler(IHouseProjectDbContext houseProjectDbContext, IMapper maper)
        {
            _houseProjectDbContext = houseProjectDbContext;
            _mapper = maper;
        }

        public async Task<Result<GetFinanceDto>> Handle(GetFinanceDetailQuery request, CancellationToken cancellationToken)
        {
            var result = await _houseProjectDbContext.Finances.ProjectTo<GetFinanceDto>(_mapper.ConfigurationProvider).FirstOrDefaultAsync();

            return Result<GetFinanceDto>.Success(result);

        }
    }
}
