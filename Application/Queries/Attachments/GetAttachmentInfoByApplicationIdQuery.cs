using Application.Core;
using Application.Dto.Attachments;
using MediatR;
using System.Collections.Generic;

namespace Application.Queries.Attachments
{
    public record GetAttachmentInfoByApplicationIdQuery(int applicationId) : IRequest<Response<List<AttachmentDto>>>
    {
    }
}
