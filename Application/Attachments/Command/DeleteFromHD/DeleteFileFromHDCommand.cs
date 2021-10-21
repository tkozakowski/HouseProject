using Application.Core;
using MediatR;

namespace Application.Attachments.Command.DeleteFromHD
{
    public class DeleteFileFromHDCommand: IRequest<Response<Unit>>
    {
        public int AttachmentId { get; set; }
    }
}
