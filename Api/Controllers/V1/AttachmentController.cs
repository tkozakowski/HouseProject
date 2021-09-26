using Application.Command.Attachment;
using Application.Dto.Attachments;
using Application.Queries.Attachments;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Api.Controllers.V1
{
    [Route("api/[controller]")]
    [Authorize]
    [ApiVersion("1.0")]
    [ApiController]
    public class AttachmentController : BaseApiController
    {
        [HttpPost("[action]")]
        public async Task<ActionResult<AttachmentDto>> GetInfoAsync(int id)
        {
            return HandleResult<AttachmentDto>(await Mediator.Send(new GetAttachmentInfoByApplicationIdQuery() { ApplicationId = id }));
        }

        [HttpPost("[action]")]
        public async Task<ActionResult<DownloadAttachmentDto>> DownloadFileAsync(int id)
        {
            return HandleResult<DownloadAttachmentDto>(await Mediator.Send(new DownloadAttachmentByIdQuery { Id = id }));
        }

        [HttpPost("[action]")]
        public async Task<ActionResult> AddFileAsync(int id, [FromBody] IFormFile formFile)
        {
            return HandleResult<AttachmentDto>(await Mediator.Send(new AddAttachmentToApplicationCommand(id, formFile)));
        }
    }
}
