using Application.Core;
using MediatR;

namespace Application.Attachments.Command.DeleteAttachment
{
    public class DeleteFileByIdCommand: IRequest<Response<Unit>>
    {
        public int AttachmentId { get; set;}
    }
}
