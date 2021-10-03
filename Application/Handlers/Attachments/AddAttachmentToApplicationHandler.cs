using Application.Command.Attachment;
using Application.Command.AttachmentBackup;
using Application.Core;
using Application.Dto.Attachments;
using Application.Extensions;
using AutoMapper;
using Domain.Entities;
using Domain.Interfaces;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Handlers.Attachments
{
    public class AddAttachmentToApplicationHandler : IRequestHandler<AddAttachmentToApplicationCommand, Response<AttachmentDto>>
    {
        private readonly IMapper _mapper;
        private readonly IAttachmentRepository _attachmentRepository;
        private readonly IApplicationRepository _applicationRepository;
        private readonly IMediator _mediator;

        public AddAttachmentToApplicationHandler(IMapper mapper, IMediator mediator, IAttachmentRepository attachmentRepository, IApplicationRepository applicationRepository)
        {
            _mapper = mapper;
            _mediator = mediator;
            _attachmentRepository = attachmentRepository;
            _applicationRepository = applicationRepository;
        }

        public async Task<Response<AttachmentDto>> Handle(AddAttachmentToApplicationCommand request, CancellationToken cancellationToken)
        {
            var application = await _applicationRepository.GetByIdAsync(request.applicationId);

            if (application is null) return null;

            var attachment = new Attachment
            {
                Name = request.file.FileName,
                Application = application,
                Path = request.file.SaveFile()
            };


            var success = await _attachmentRepository.AddAsync(attachment);

            if (!success) return Response<AttachmentDto>.Failure("Failed to add new attachment");

            await _mediator.Send(new AddAttachmentBackupToApplicationCommand(request.applicationId, request.file));

            var attachmentDto = _mapper.Map<AttachmentDto>(attachment);

            return Response<AttachmentDto>.Success(attachmentDto);
        }
    }
}
