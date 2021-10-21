using Application.Core;
using MediatR;
using Microsoft.AspNetCore.Http;

namespace Application.Attachments.Command.AddAttachment
{
    public class AddAttachmentToApplicationCommand : IRequest<Response<Unit>>
    {
        public int ApplicationId { get; set;}
        public IFormFile File { get; set; }
    }
}
