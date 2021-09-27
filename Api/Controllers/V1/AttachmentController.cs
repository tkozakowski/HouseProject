using Application.Command.Attachment;
using Application.Dto.Attachments;
using Application.Queries.Attachments;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Net.Mime;
using System.Threading.Tasks;

namespace Api.Controllers.V1
{
    [Route("api/[controller]")]
    //[Authorize]
    [ApiVersion("1.0")]
    [ApiController]
    public class AttachmentController : BaseApiController
    {
        [HttpGet("[action]/{applicationId}")]
        public async Task<ActionResult<AttachmentDto>> GetAttachmentsInfoByApplicationIdAsync(int applicationId)
        {
            return HandleResult<List<AttachmentDto>>(await Mediator.Send(new GetAttachmentInfoByApplicationIdQuery(applicationId)));
        }

        [HttpGet("[action]/{fileId}")]
        public async Task<ActionResult<DownloadAttachmentDto>> GetFileAsync(int fileId)
        {
            var attachment = await Mediator.Send(new DownloadFileByIdQuery(fileId));

            return File(attachment.Content, MediaTypeNames.Application.Octet, attachment.Name);
        }

        [HttpPost("[action]/{applicationId}")]
        public async Task<ActionResult> AddFileAsync(int applicationId, IFormFile formFile)
        {
            return HandleResult<AttachmentDto>(await Mediator.Send(new AddAttachmentToApplicationCommand(applicationId, formFile)));
        }

        [HttpDelete("[action]/{fileId}")]
        public async Task<ActionResult> DeleteFileAsync(int fileId)
        {
            return HandleResult(await Mediator.Send(new DeleteFileByIdCommand(fileId)));
        }
    }
}
