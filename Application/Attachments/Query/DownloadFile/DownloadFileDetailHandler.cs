using Application.Core;
using Application.Dto.Attachments;
using Application.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.IO;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Attachments.Query.DownloadFile
{
    public class DownloadFileDetailHandler : IRequestHandler<DownloadFileDetailQuery, DownloadFileDto>
    {
        private readonly IHouseProjectDbContext _houseProjectDbContext ;

        public DownloadFileDetailHandler(IHouseProjectDbContext houseProjectDbContext)
        {
            _houseProjectDbContext = houseProjectDbContext;
        }

        public async Task<DownloadFileDto> Handle(DownloadFileDetailQuery request, CancellationToken cancellationToken)
        {
            var attachment = await _houseProjectDbContext.Attachments.FirstOrDefaultAsync(x => x.Id == request.attachmentId && !x.IsDeleted);

            if (attachment is null) return null;

            var downloadAttachmentDto = new DownloadFileDto
            {
                Name = attachment.Name,
                Content = File.ReadAllBytes(attachment.Path)
            };

            return downloadAttachmentDto;
        }
    }
}
