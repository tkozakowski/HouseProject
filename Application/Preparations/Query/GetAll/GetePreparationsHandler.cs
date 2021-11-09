using Application.Core;
using Application.Interfaces;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Preparations.Query.GetAll
{
    public class GetePreparationsHandler : IRequestHandler<GetPreparationsQuery, Result<IEnumerable<GetPreparationsDto>>>
    {
        private readonly IHouseProjectDbContext _houseProjectDbContext;
        private readonly IMapper _mapper;

        public GetePreparationsHandler(IHouseProjectDbContext houseProjectDbContext, IMapper mapper)
        {
            _houseProjectDbContext = houseProjectDbContext;
            _mapper = mapper;
        }

        public async Task<Result<IEnumerable<GetPreparationsDto>>> Handle(GetPreparationsQuery request, CancellationToken cancellationToken)
        {
            var result = await _houseProjectDbContext.Preparations.Include(p => p.Documents).ProjectTo<GetPreparationsDto>(_mapper.ConfigurationProvider).ToListAsync();

            return Result<IEnumerable<GetPreparationsDto>>.Success(result);
        }
    }
}
