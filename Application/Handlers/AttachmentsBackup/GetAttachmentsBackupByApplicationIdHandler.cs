using Application.Core;
using Application.Dto.AttachmentsBackup;
using Application.Interfaces;
using Application.Queries.AttachmentsBackup;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Handlers.AttachmentsBackup
{
    public class GetAttachmentsBackupByApplicationIdHandler : IRequestHandler<GetAttachmentsBackupByApplicationIdQuery, Response<IEnumerable<AttachmentBackupsInfoDto>>>
    {
        private readonly IHouseProjectDbContext _houseProjectDbContext;
        private readonly IMapper _mapper;

        public GetAttachmentsBackupByApplicationIdHandler(IHouseProjectDbContext houseProjectDbContext, IMapper mapper)
        {
            _houseProjectDbContext = houseProjectDbContext;
            _mapper = mapper;
        }

        public async Task<Response<IEnumerable<AttachmentBackupsInfoDto>>> Handle(GetAttachmentsBackupByApplicationIdQuery request, CancellationToken cancellationToken)
        {
            var attachments = await _houseProjectDbContext.AttachmentsBackup
                .Where(x => x.ApplicationId == request.applicationId)
                .ProjectTo<AttachmentBackupsInfoDto>(_mapper.ConfigurationProvider)
                .ToListAsync();

            return Response<IEnumerable<AttachmentBackupsInfoDto>>.Success(attachments);
        }
    }
}
