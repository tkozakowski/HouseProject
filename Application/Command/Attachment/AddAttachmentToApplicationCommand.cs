using Application.Core;
using Application.Dto.Attachments;
using MediatR;
using Microsoft.AspNetCore.Http;

namespace Application.Command.Attachment
{
    public record AddAttachmentToApplicationCommand(int applicationId, IFormFile file) : IRequest<Response<AttachmentDto>>
    {
    }
}
