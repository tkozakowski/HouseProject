using Application.Core;
using MediatR;
using System.Collections.Generic;

namespace Application.Attachments.Query.GetAttachmentInfo
{
    public record GetApplicatedAttachmentQuery(int applicationId) : IRequest<Result<List<GetApplicatedAttachmentsDto>>>
    {
    }
}
