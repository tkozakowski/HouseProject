using MediatR;
using Microsoft.AspNetCore.Http;

namespace Application.Command.AttachmentBackup
{
    public record AddAttachmentBackupToApplicationCommand(int applicationId, IFormFile formFile) : IRequest<Unit>
    {
    }
}
