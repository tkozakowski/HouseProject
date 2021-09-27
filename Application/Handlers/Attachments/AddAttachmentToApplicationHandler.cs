using Application.Command.Attachment;
using Application.Command.AttachmentBackup;
using Application.Core;
using Application.Dto.Attachments;
using Application.Extensions;
using Application.Interfaces;
using AutoMapper;
using Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Handlers.Attachments
{
    public class AddAttachmentToApplicationHandler : IRequestHandler<AddAttachmentToApplicationCommand, Response<AttachmentDto>>
    {
        private readonly IMapper _mapper;
        private readonly IHouseProjectDbContext _houseProjectDbContext;
        private readonly IMediator _mediator;

        public AddAttachmentToApplicationHandler(IMapper mapper, IHouseProjectDbContext houseProjectDbContext, IMediator mediator)
        {
            _mapper = mapper;
            _houseProjectDbContext = houseProjectDbContext;
            _mediator = mediator;
        }

        public async Task<Response<AttachmentDto>> Handle(AddAttachmentToApplicationCommand request, CancellationToken cancellationToken)
        {
            var application = await _houseProjectDbContext.Applications.FirstOrDefaultAsync(a => a.Id == request.applicationId);

            if (application is null) return null;

            var attachment = new Attachment
            {
                Name = request.file.FileName,
                Application = application,
                Path = request.file.SaveFile()
            };

            _houseProjectDbContext.Attachments.Add(attachment);

            var success = await _houseProjectDbContext.SaveChangesAsync() > 0;

            if (!success) return Response<AttachmentDto>.Failure("Failed to add new attachment");


            await _mediator.Send(new AddAttachmentBackupToApplicationCommand(request.applicationId, request.file));


            var attachmentDto = _mapper.Map<AttachmentDto>(attachment);

            return Response<AttachmentDto>.Success(attachmentDto);
        }
    }
}
