using Application.Core;
using Application.Interfaces;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Application.AttachmentsSmall.Query.GetAll
{
    public class GetSmallFilesHandler : IRequestHandler<GetSmallFilesQuery, Response<IEnumerable<SmallFileDetailDto>>>
    {
        private readonly IHouseProjectDbContext _houseProjectDbContext;
        private readonly IMapper _mapper;

        public GetSmallFilesHandler(IHouseProjectDbContext houseProjectDbContext, IMapper mapper)
        {
            _houseProjectDbContext = houseProjectDbContext;
            _mapper = mapper;
        }

        public async Task<Response<IEnumerable<SmallFileDetailDto>>> Handle(GetSmallFilesQuery request, CancellationToken cancellationToken)
        {
            var attachments = await _houseProjectDbContext.AttachmentsBackup.Where(x => x.ApplicationId == request.applicationId && !x.IsDeleted).ProjectTo<SmallFileDetailDto>(_mapper.ConfigurationProvider).ToListAsync();

            if (attachments is not null) 
                return Response<IEnumerable<SmallFileDetailDto>>.Failure("Failed to get attachments");

            return Response<IEnumerable<SmallFileDetailDto>>.Success(attachments);
        }
    }
}
