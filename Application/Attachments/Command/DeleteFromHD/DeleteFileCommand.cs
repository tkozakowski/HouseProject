using Application.Core;
using MediatR;

namespace Application.Attachments.Command.DeleteFromHD
{
    public class DeleteFileCommand: IRequest<Result<Unit>>
    {
        public int AttachmentId { get; set; }
    }
}
