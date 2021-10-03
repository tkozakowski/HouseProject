using Application.Dto.Attachments;
using Application.Queries.Attachments;
using Domain.Interfaces;
using MediatR;
using System.IO;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Handlers.Attachments
{
    public class DownloadFileByIdHandler : IRequestHandler<DownloadFileByIdQuery, DownloadAttachmentDto>
    {
        private readonly IAttachmentRepository _attachmentRepository;

        public DownloadFileByIdHandler(IAttachmentRepository attachmentRepository)
        {
            _attachmentRepository = attachmentRepository;
        }

        public async Task<DownloadAttachmentDto> Handle(DownloadFileByIdQuery request, CancellationToken cancellationToken)
        {
            var attachment = await _attachmentRepository.GetByIdAsync(request.attachmentId);

            var downloadAttachmentDto = new DownloadAttachmentDto
            {
                Name = attachment.Name,
                Content = File.ReadAllBytes(attachment.Path)
            };

            return downloadAttachmentDto;
        }
    }
}
