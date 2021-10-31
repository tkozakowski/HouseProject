using Application.Core;
using Application.Interfaces;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Cosmonaut.Extensions;
using MediatR;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Application.AttachmentsSmall.Query.GetDetail
{
    class GetFileDetailHandler : IRequestHandler<GetFileDetailQuery, Result<GetFileDetailDto>>
    {
        private readonly IHouseProjectDbContext _houseProjectDbContext;
        private readonly IMapper _mapper;

        public GetFileDetailHandler(IHouseProjectDbContext houseProjectDbContext, IMapper mapper)
        {
            _houseProjectDbContext = houseProjectDbContext;
            _mapper = mapper;
        }

        public async Task<Result<GetFileDetailDto>> Handle(GetFileDetailQuery request, CancellationToken cancellationToken)
        {
            var result = await _houseProjectDbContext.AttachmentsSmall.Where(x => x.Id == request.fileId && !x.IsDeleted)
                .ProjectTo<GetFileDetailDto>(_mapper.ConfigurationProvider).FirstOrDefaultAsync();

            if (result is null || result.File.Length <= 0) 
                return Result<GetFileDetailDto>.Failure("Failed to get requested file");

            return Result<GetFileDetailDto>.Success(result);
        }
    }
}
