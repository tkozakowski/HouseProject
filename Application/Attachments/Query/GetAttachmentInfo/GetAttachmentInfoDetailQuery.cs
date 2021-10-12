using Application.Core;
using MediatR;
using System.Collections.Generic;

namespace Application.Attachments.Query.GetAttachmentInfo
{
    public record GetAttachmentInfoDetailQuery(int applicationId) : IRequest<Response<List<GetAttachmentDto>>>
    {
    }
}
