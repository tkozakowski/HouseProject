using Application.Dto.Attachments;
using MediatR;

namespace Application.Attachments.Query.DownloadFile
{
    public record DownloadFileDetailQuery(int attachmentId) : IRequest<DownloadFileDto>
    {
    }
}
