using Application.Core;
using Application.Dto.AttachmentsBackup;
using MediatR;
using System.Collections.Generic;

namespace Application.Queries.AttachmentsBackup
{
    public record GetAttachmentsBackupByApplicationIdQuery(int applicationId) : IRequest<Response<IEnumerable<AttachmentBackupsInfoDto>>>
    {
    }
}
