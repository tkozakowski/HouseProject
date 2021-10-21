using Application.Core;
using AutoMapper;
using Domain.Interfaces;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Application.AttachmentsDb.Query.Get
{
    public class GetSmallFileHandler : IRequestHandler<GetSmallFileQuery, Response<IEnumerable<SmallFileDetailDto>>>
    {
        private readonly IAttachmentRepository _attachmentRepository;
        private readonly IMapper _mapper;

        public GetSmallFileHandler(IMapper mapper, IAttachmentRepository attachmentRepository)
        {
            _mapper = mapper;
            _attachmentRepository = attachmentRepository;
        }

        public async Task<Response<IEnumerable<SmallFileDetailDto>>> Handle(GetSmallFileQuery request, CancellationToken cancellationToken)
        {
            var attachments = await _attachmentRepository.GetAttachmentsBackupByApplicationIdAsync(request.applicationId);

            var attachmentBackupsInfoDto = _mapper.Map<List<SmallFileDetailDto>>(attachments);

            return Response<IEnumerable<SmallFileDetailDto>>.Success(attachmentBackupsInfoDto);
        }
    }
}
