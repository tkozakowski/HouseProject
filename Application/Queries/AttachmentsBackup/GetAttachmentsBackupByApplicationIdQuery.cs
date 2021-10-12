using Application.AttachmentsBackup.Query.Get;
using Application.Core;
using MediatR;
using System.Collections.Generic;

namespace Application.Queries.AttachmentsBackup
{
    public record GetAttachmentsBackupByApplicationIdQuery(int applicationId) : IRequest<Response<IEnumerable<AttachmentBackupsInfoDto>>>
    {
    }
}
