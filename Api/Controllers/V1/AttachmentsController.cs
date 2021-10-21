using Application.Attachments.Command.AddAttachment;
using Application.Attachments.Command.DeleteFromHD;
using Application.Attachments.Query.DownloadFile;
using Application.Attachments.Query.GetAttachmentInfo;
using Application.AttachmentsSmall.Query.GetAll;
using Application.AttachmentsSmall.Query.GetDetail;
using Application.Dto.Attachments;
using Application.Interfaces;
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
    public class AttachmentsController : BaseApiController
    {
        private readonly IAttachmentService _attachmentComparerService;

        public AttachmentsController(IAttachmentService attachmentComparerService)
        {
            _attachmentComparerService = attachmentComparerService;
        }


        [HttpGet("[action]/{applicationId}")]
        public async Task<ActionResult<GetAttachmentDto>> GetAttachmentsInfoByApplicationIdAsync(int applicationId)
        {
            return HandleResult<List<GetAttachmentDto>>(await Mediator.Send(new GetAttachmentInfoDetailQuery(applicationId)));
        }

        [HttpGet("[action]/{applicationId}")]
        public async Task<ActionResult<IEnumerable<SmallFileDto>>> DownloadSmallFilesByApplicationAsync(int applicationId)
        {
            return HandleResult(await Mediator.Send(new GetSmallFilesByApplicationQuery(applicationId)));
        }

        [HttpGet("[action]/{fileId}")]
        public async Task<ActionResult<DownloadFileDto>> GetFileAsync(int fileId)
        {
            var attachment = await Mediator.Send(new DownloadFileDetailQuery(fileId));

            return File(attachment.Content, MediaTypeNames.Application.Octet, attachment.Name);
        }


        [HttpPost("[action]/{applicationId}")]
        public async Task<ActionResult> AddFileAsync(int applicationId, IFormFile formFile)
        {
            return HandleResult(await Mediator.Send(new AddAttachmentToApplicationCommand { ApplicationId = applicationId, 
                File = formFile }));
        }

        [HttpDelete("[action]/{fileId}")]
        public async Task<ActionResult> DeleteFileAsync(int fileId)
        {
            return HandleResult(await Mediator.Send(new DeleteFileCommand { AttachmentId = fileId }));
        }


        [HttpGet("[action]")]
        public async Task<ActionResult> RecoverBackupFiles()
        {
            await _attachmentComparerService.RecoverFiles();

            return NoContent();
        }
    }
}
