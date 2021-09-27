using Application.Core;
using Application.Dto.Attachments;
using Application.Interfaces;
using Application.Queries.Attachments;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Handlers.Attachments
{
    public class GetAttachmentInfoByApplicationIdHandler : IRequestHandler<GetAttachmentInfoByApplicationIdQuery, Response<List<AttachmentDto>>>
    {
        private readonly IHouseProjectDbContext _houseProjectDbContext;
        private readonly IMapper _mapper;

        public GetAttachmentInfoByApplicationIdHandler(IHouseProjectDbContext houseProjectDbContext, IMapper mapper)
        {
            _houseProjectDbContext = houseProjectDbContext;
            _mapper = mapper;
        }
        public async Task<Response<List<AttachmentDto>>> Handle(GetAttachmentInfoByApplicationIdQuery request, CancellationToken cancellationToken)
        {
            var result = await _houseProjectDbContext
                .Attachments.Include(a => a.Application)
                .Where(x => x.ApplicationId == request.applicationId)
                .ProjectTo<AttachmentDto>(_mapper.ConfigurationProvider)
                .ToListAsync();

            return Response<List<AttachmentDto>>.Success(result);
        }
    }
}
