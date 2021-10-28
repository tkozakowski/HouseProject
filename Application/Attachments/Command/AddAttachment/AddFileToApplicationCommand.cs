using Application.Core;
using MediatR;
using Microsoft.AspNetCore.Http;

namespace Application.Attachments.Command.AddAttachment
{
    public class AddFileToApplicationCommand : IRequest<Result<Unit>>
    {
        public int ApplicationId { get; set;}
        public IFormFile File { get; set; }
    }
}
