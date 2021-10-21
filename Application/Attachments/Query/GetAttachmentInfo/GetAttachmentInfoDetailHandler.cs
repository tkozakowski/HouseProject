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

namespace Application.Attachments.Query.GetAttachmentInfo
{
    public class GetAttachmentInfoDetailHandler : IRequestHandler<GetAttachmentInfoDetailQuery, Response<List<GetAttachmentDto>>>
    {
        private readonly IHouseProjectDbContext _houseProjectDbContext;
        private readonly IMapper _mapper;

        public GetAttachmentInfoDetailHandler(IHouseProjectDbContext houseProjectDbContext, IMapper mapper)
        {
            _houseProjectDbContext = houseProjectDbContext;
            _mapper = mapper;
        }

        public async Task<Response<List<GetAttachmentDto>>> Handle(GetAttachmentInfoDetailQuery request, CancellationToken cancellationToken)
        {
            var attachmentsDto = await _houseProjectDbContext.SendApplications
                .Include(x => x.Attachments)
                .Where(x => x.Id == request.applicationId)
                .ProjectTo<List<GetAttachmentDto>>(_mapper.ConfigurationProvider)
                .FirstOrDefaultAsync();

            return Response<List<GetAttachmentDto>>.Success(attachmentsDto);
        }
    }
}
