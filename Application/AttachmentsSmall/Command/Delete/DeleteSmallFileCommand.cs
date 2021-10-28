using Application.Core;
using MediatR;

namespace Application.AttachmentsSmall.Command.DeleteFromDb
{
    public class DeleteSmallFileCommand: IRequest<Result<Unit>>
    {
        public int AttachmentId { get; set;}
    }
}
