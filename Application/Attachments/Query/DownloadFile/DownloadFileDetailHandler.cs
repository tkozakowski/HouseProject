using Application.Dto.Attachments;
using Domain.Interfaces;
using MediatR;
using System.IO;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Attachments.Query.DownloadFile
{
    public class DownloadFileDetailHandler : IRequestHandler<DownloadFileDetailQuery, DownloadAttachmentDto>
    {
        private readonly IAttachmentRepository _attachmentRepository;

        public DownloadFileDetailHandler(IAttachmentRepository attachmentRepository)
        {
            _attachmentRepository = attachmentRepository;
        }

        public async Task<DownloadAttachmentDto> Handle(DownloadFileDetailQuery request, CancellationToken cancellationToken)
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
