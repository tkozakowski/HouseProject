using Application.Core;
using MediatR;
using Microsoft.AspNetCore.Http;

namespace Application.AttachmentsSmall.Command.Add
{
    public class AdSmallFileToApplicationCommand : IRequest<Response<Unit>>
    {
        public int ApplicationId { get; set; }
        public IFormFile FormFile { get; set; }
    }
}
