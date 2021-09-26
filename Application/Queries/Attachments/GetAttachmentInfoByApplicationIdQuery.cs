using Application.Core;
using Application.Dto.Attachments;
using MediatR;

namespace Application.Queries.Attachments
{
    public class GetAttachmentInfoByApplicationIdQuery: IRequest<Response<AttachmentDto>>
    {
        public int ApplicationId { get; set; }
    }
}
