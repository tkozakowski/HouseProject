using Application.Core;
using Application.Interfaces;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Materials.Query.GetDetail
{
    public class GetMaterialDetailHandler : IRequestHandler<GetMaterialDetailQuery, Result<GetMaterialDto>>
    {
        private readonly IHouseProjectDbContext _houseProjectDbContext;
        private readonly IMapper _mapper;

        public GetMaterialDetailHandler(IHouseProjectDbContext houseProjectDbContext, IMapper mapper)
        {
            _houseProjectDbContext = houseProjectDbContext;
            _mapper = mapper;
        }

        public async Task<Result<GetMaterialDto>> Handle(GetMaterialDetailQuery request, CancellationToken cancellationToken)
        {
            var material = await _houseProjectDbContext.Materials.Where(x => x.Id == request.id).ProjectTo<GetMaterialDto>(_mapper.ConfigurationProvider).FirstOrDefaultAsync();

            if (material is null) return Result<GetMaterialDto>.Failure("Failed to get requested material");

            return Result<GetMaterialDto>.Success(material);
        }
    }
}
