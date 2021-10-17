using Application.AttachmentsBackup.Command.Add;
using Application.Core;
using Application.Extensions;
using AutoMapper;
using Domain.Entities;
using Domain.Interfaces;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Attachments.Command.AddAttachment
{
    public class AddAttachmentToApplicationHandler : IRequestHandler<AddAttachmentToApplicationCommand, Response<AddAttachmentDto>>
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

        public async Task<Response<AddAttachmentDto>> Handle(AddAttachmentToApplicationCommand request, CancellationToken cancellationToken)
        {
            var application = await _applicationRepository.GetByIdAsync(request.ApplicationId);

            if (application is null) return null;

            var attachment = new Attachment
            {
                Name = request.File.FileName,
                Application = application,
                Path = request.File.SaveFile()
            };


            var success = await _attachmentRepository.AddAsync(attachment);

            if (!success) return Response<AddAttachmentDto>.Failure("Failed to add new attachment");

            await _mediator.Send(new AddAttachmentBackupToApplicationCommand(request.ApplicationId, request.File));

            var attachmentDto = _mapper.Map<AddAttachmentDto>(attachment);

            return Response<AddAttachmentDto>.Success(attachmentDto);
        }
    }
}
