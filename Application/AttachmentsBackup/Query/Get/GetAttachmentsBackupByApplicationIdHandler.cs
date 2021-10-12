using Application.Core;
using AutoMapper;
using Domain.Interfaces;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Application.AttachmentsBackup.Query.Get
{
    public class GetAttachmentsBackupByApplicationIdHandler : IRequestHandler<GetAttachmentsBackupByApplicationIdQuery, Response<IEnumerable<AttachmentBackupsInfoDto>>>
    {
        private readonly IAttachmentRepository _attachmentRepository;
        private readonly IMapper _mapper;

        public GetAttachmentsBackupByApplicationIdHandler(IMapper mapper, IAttachmentRepository attachmentRepository)
        {
            _mapper = mapper;
            _attachmentRepository = attachmentRepository;
        }

        public async Task<Response<IEnumerable<AttachmentBackupsInfoDto>>> Handle(GetAttachmentsBackupByApplicationIdQuery request, CancellationToken cancellationToken)
        {
            var attachments = await _attachmentRepository.GetAttachmentsBackupByApplicationIdAsync(request.applicationId);

            var attachmentBackupsInfoDto = _mapper.Map<List<AttachmentBackupsInfoDto>>(attachments);

            return Response<IEnumerable<AttachmentBackupsInfoDto>>.Success(attachmentBackupsInfoDto);
        }
    }
}
