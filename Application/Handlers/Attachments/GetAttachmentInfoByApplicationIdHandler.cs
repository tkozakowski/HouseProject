using Application.Core;
using Application.Dto.Attachments;
using Application.Queries.Attachments;
using AutoMapper;
using Domain.Interfaces;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Handlers.Attachments
{
    public class GetAttachmentInfoByApplicationIdHandler : IRequestHandler<GetAttachmentInfoByApplicationIdQuery, Response<List<AttachmentDto>>>
    {
        private readonly IAttachmentRepository _attachmentRepository;
        private readonly IMapper _mapper;

        public GetAttachmentInfoByApplicationIdHandler(IAttachmentRepository attachmentRepository, IMapper mapper)
        {
            _attachmentRepository = attachmentRepository;
            _mapper = mapper;
        }



        public async Task<Response<List<AttachmentDto>>> Handle(GetAttachmentInfoByApplicationIdQuery request, CancellationToken cancellationToken)
        {
            var attachments = await _attachmentRepository.GetAttachmentsByApplicationIdAsync(request.applicationId);

            var attachmentsDto = _mapper.Map<List<AttachmentDto>>(attachments);

            return Response<List<AttachmentDto>>.Success(attachmentsDto);
        }
    }
}
