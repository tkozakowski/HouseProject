using Application.Core;
using Application.Dto.Attachments;
using MediatR;

namespace Application.Queries.Attachments
{
    public class DownloadAttachmentByIdQuery : IRequest<Response<DownloadAttachmentDto>>
    {
        public int Id { get; set; }
    }
}
