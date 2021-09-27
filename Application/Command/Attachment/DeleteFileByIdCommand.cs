using Application.Core;
using MediatR;

namespace Application.Command.Attachment
{
    public record DeleteFileByIdCommand(int attachmentId): IRequest<Response<Unit>>
    {
    }
}
