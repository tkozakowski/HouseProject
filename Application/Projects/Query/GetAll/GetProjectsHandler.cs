using Application.Core;
using Application.Interfaces;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Projects.Query.GetAll
{
    public class GetProjectsHandler : IRequestHandler<GetProjectsQuery, Result<IEnumerable<GetProjectDto>>>
    {
        private readonly IHouseProjectDbContext _houseProjectDbContext;
        private readonly IMapper _mapper;

        public GetProjectsHandler(IHouseProjectDbContext houseProjectDbContext, IMapper mapper)
        {
            _houseProjectDbContext = houseProjectDbContext;
            _mapper = mapper;
        }

        public async Task<Result<IEnumerable<GetProjectDto>>> Handle(GetProjectsQuery request, CancellationToken cancellationToken)
        {
            var result = await _houseProjectDbContext.Projects.ProjectTo<GetProjectDto>(_mapper.ConfigurationProvider).ToListAsync();

            return Result<IEnumerable<GetProjectDto>>.Success(result);
        }
    }
}
