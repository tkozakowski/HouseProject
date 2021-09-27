using Application.Dto.Attachments;
using Application.Interfaces;
using Application.Queries.Attachments;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Handlers.Attachments
{
    public class DownloadFileByIdHandler : IRequestHandler<DownloadFileByIdQuery, DownloadAttachmentDto>
    {
        private readonly IHouseProjectDbContext _houseProjectDbContext;

        public DownloadFileByIdHandler(IHouseProjectDbContext houseProjectDbContext)
        {
            _houseProjectDbContext = houseProjectDbContext;
        }

        public async Task<DownloadAttachmentDto> Handle(DownloadFileByIdQuery request, CancellationToken cancellationToken)
        {
            var attachment = await _houseProjectDbContext.Attachments.Where(x => x.Id == request.attachmentId).FirstOrDefaultAsync();

            var downloadAttachmentDto = new DownloadAttachmentDto
            {
                Name = attachment.Name,
                Content = File.ReadAllBytes(attachment.Path)
            };

            return downloadAttachmentDto;
        }
    }
}
