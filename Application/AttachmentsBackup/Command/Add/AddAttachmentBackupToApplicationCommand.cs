using MediatR;
using Microsoft.AspNetCore.Http;

namespace Application.AttachmentsBackup.Command.Add
{
    public record AddAttachmentBackupToApplicationCommand(int applicationId, IFormFile formFile) : IRequest<Unit>
    {
    }
}
