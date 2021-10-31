using Application.Core;
using Application.Interfaces;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Materials.Query.GetAll
{
    public class GetAllMaterialsHandler : IRequestHandler<GetAllMaterialsQuery, Result<IEnumerable<GetAllMaterialsDto>>>
    {
        private readonly IHouseProjectDbContext _houseProjectDbContext;
        private readonly IMapper _mapper;

        public GetAllMaterialsHandler(IHouseProjectDbContext houseProjectDbContext, IMapper mapper)
        {
            _houseProjectDbContext = houseProjectDbContext;
            _mapper = mapper;
        }

        public async Task<Result<IEnumerable<GetAllMaterialsDto>>> Handle(GetAllMaterialsQuery request, CancellationToken cancellationToken)
        {
            var materials = await _houseProjectDbContext.Materials.ProjectTo<GetAllMaterialsDto>(_mapper.ConfigurationProvider).ToListAsync();

            return Result<IEnumerable<GetAllMaterialsDto>>.Success(materials);
        }
    }
}
