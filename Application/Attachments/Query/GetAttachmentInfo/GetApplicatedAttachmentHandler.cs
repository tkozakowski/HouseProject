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
    public class GetApplicatedAttachmentHandler : IRequestHandler<GetApplicatedAttachmentQuery, Response<List<GetApplicatedAttachmentsDto>>>
    {
        private readonly IHouseProjectDbContext _houseProjectDbContext;
        private readonly IMapper _mapper;

        public GetApplicatedAttachmentHandler(IHouseProjectDbContext houseProjectDbContext, IMapper mapper)
        {
            _houseProjectDbContext = houseProjectDbContext;
            _mapper = mapper;
        }

        public async Task<Response<List<GetApplicatedAttachmentsDto>>> Handle(GetApplicatedAttachmentQuery request, CancellationToken cancellationToken)
        {
            var attachmentsDto = await _houseProjectDbContext.SendApplications
                .Include(x => x.Attachments)
                .Where(x => x.Id == request.applicationId)
                .ProjectTo<GetApplicatedAttachmentsDto>(_mapper.ConfigurationProvider)
                .ToListAsync();

            return Response<List<GetApplicatedAttachmentsDto>>.Success(attachmentsDto);
        }
    }
}
