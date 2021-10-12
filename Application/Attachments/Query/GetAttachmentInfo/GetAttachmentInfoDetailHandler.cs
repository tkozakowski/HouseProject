using Application.Core;
using AutoMapper;
using Domain.Interfaces;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Attachments.Query.GetAttachmentInfo
{
    public class GetAttachmentInfoDetailHandler : IRequestHandler<GetAttachmentInfoDetailQuery, Response<List<GetAttachmentDto>>>
    {
        private readonly IAttachmentRepository _attachmentRepository;
        private readonly IMapper _mapper;

        public GetAttachmentInfoDetailHandler(IAttachmentRepository attachmentRepository, IMapper mapper)
        {
            _attachmentRepository = attachmentRepository;
            _mapper = mapper;
        }



        public async Task<Response<List<GetAttachmentDto>>> Handle(GetAttachmentInfoDetailQuery request, CancellationToken cancellationToken)
        {
            var attachments = await _attachmentRepository.GetAttachmentsByApplicationIdAsync(request.applicationId);

            var attachmentsDto = _mapper.Map<List<GetAttachmentDto>>(attachments);

            return Response<List<GetAttachmentDto>>.Success(attachmentsDto);
        }
    }
}
