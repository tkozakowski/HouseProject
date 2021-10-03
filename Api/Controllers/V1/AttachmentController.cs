using Application.Command.Attachment;
using Application.Dto.Attachments;
using Application.Dto.AttachmentsBackup;
using Application.Interfaces;
using Application.Queries.Attachments;
using Application.Queries.AttachmentsBackup;
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
        private readonly IAttachmentService _attachmentComparerService;

        public AttachmentController(IAttachmentService attachmentComparerService)
        {
            _attachmentComparerService = attachmentComparerService;
        }


        [HttpGet("[action]/{applicationId}")]
        public async Task<ActionResult<AttachmentDto>> GetAttachmentsInfoByApplicationIdAsync(int applicationId)
        {
            return HandleResult<List<AttachmentDto>>(await Mediator.Send(new GetAttachmentInfoByApplicationIdQuery(applicationId)));
        }

        [HttpGet("[action]/{applicationId}")]
        public async Task<ActionResult<IEnumerable<AttachmentBackupsInfoDto>>> GetAttachmentsBackupInfoByApplicationIdAsync(int applicationId)
        {
            return HandleResult(await Mediator.Send(new GetAttachmentsBackupByApplicationIdQuery(applicationId)));
        }

        [HttpGet("[action]/{fileId}")]
        public async Task<ActionResult<DownloadAttachmentDto>> GetFileAsync(int fileId)
        {
            var attachment = await Mediator.Send(new DownloadFileByIdQuery(fileId));

            return File(attachment.Content, MediaTypeNames.Application.Octet, attachment.Name);
        }

        //[HttpGet("[action]/fileId")]
        //public async Task<ActionResult> GetBackupAttachmentAsync(int fileId)
        //{

        //}


        [HttpPost("[action]/{applicationId}")]
        public async Task<ActionResult> AddFileAttachmentAsync(int applicationId, IFormFile formFile)
        {
            return HandleResult<AttachmentDto>(await Mediator.Send(new AddAttachmentToApplicationCommand(applicationId, formFile)));
        }

        [HttpDelete("[action]/{fileId}")]
        public async Task<ActionResult> DeleteFileAsync(int fileId)
        {
            return HandleResult(await Mediator.Send(new DeleteFileByIdCommand(fileId)));
        }


        [HttpGet("[action]")]
        public async Task<ActionResult> RecoverBackupFiles()
        {
            await _attachmentComparerService.RecoverFiles();

            return NoContent();
        }
    }
}
