using Application.Core;
using MediatR;
using System.Collections.Generic;

namespace Application.AttachmentsBackup.Query.Get
{
    public record GetAttachmentsBackupByApplicationIdQuery(int applicationId) : IRequest<Response<IEnumerable<AttachmentBackupsInfoDto>>>
    {
    }
}
