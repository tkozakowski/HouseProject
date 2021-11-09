using Application.Core;
using Application.Interfaces;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Executions.Query.GetAll
{
    public class GetExecutionsHandler : IRequestHandler<GetExecutionsQuery, Result<IEnumerable<GetExecutionsDto>>>
    {
        private readonly IHouseProjectDbContext _houseProjectDbContext;
        private readonly IMapper _mapper;

        public GetExecutionsHandler(IHouseProjectDbContext houseProjectDbContext, IMapper mapper)
        {
            _houseProjectDbContext = houseProjectDbContext;
            _mapper = mapper;
        }

        public async Task<Result<IEnumerable<GetExecutionsDto>>> Handle(GetExecutionsQuery request, CancellationToken cancellationToken)
        {
            var executions = await _houseProjectDbContext.Executions
                .ProjectTo<GetExecutionsDto>(_mapper.ConfigurationProvider).ToListAsync();

            return Result<IEnumerable<GetExecutionsDto>>.Success(executions);
        }
    }
}
