using Application.Dto.Attachments;
using Domain.Interfaces;
using MediatR;
using System.IO;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Attachments.Query.DownloadFile
{
    public class DownloadFileDetailHandler : IRequestHandler<DownloadFileDetailQuery, DownloadFileDto>
    {
        private readonly IAttachmentRepository _attachmentRepository;

        public DownloadFileDetailHandler(IAttachmentRepository attachmentRepository)
        {
            _attachmentRepository = attachmentRepository;
        }

        public async Task<DownloadFileDto> Handle(DownloadFileDetailQuery request, CancellationToken cancellationToken)
        {
            var attachment = await _attachmentRepository.GetByIdAsync(request.attachmentId);

            var downloadAttachmentDto = new DownloadFileDto
            {
                Name = attachment.Name,
                Content = File.ReadAllBytes(attachment.Path)
            };

            return downloadAttachmentDto;
        }
    }
}
