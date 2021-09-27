using Application.Dto.Attachments;
using MediatR;

namespace Application.Queries.Attachments
{
    public record DownloadFileByIdQuery(int attachmentId) : IRequest<DownloadAttachmentDto>
    {
    }
}
