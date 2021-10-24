using Application.Attachments.Command.AddAttachment;
using Application.Attachments.Command.DeleteFromHD;
using Application.Attachments.Query.DownloadFile;
using Application.Attachments.Query.GetAttachmentInfo;
using Application.AttachmentsSmall.Command.Add;
using Application.AttachmentsSmall.Command.DeleteFromDb;
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

        [HttpGet("[action]/{applicationId}")]
        public async Task<ActionResult<IEnumerable<SmallFileDto>>> GetSmallFilesAsync(int applicationId)
        {
            return HandleResult(await Mediator.Send(new GetSmallFilesQuery(applicationId)));
        }

        [HttpGet("[action]/{fileId}")]
        public async Task<ActionResult<DownloadFileDto>> GetFileAsync(int fileId)
        {
            var attachment = await Mediator.Send(new DownloadFileDetailQuery(fileId));

            return File(attachment.Content, MediaTypeNames.Application.Octet, attachment.Name);
        }

        [HttpGet("[action]/{fileId}")]
        public async Task<ActionResult<GetFileDetailDto>> GetSmallFileAsync(int fileId)
        {
            var attachment = await Mediator.Send(new GetFileDetailQuery(fileId));

            return HandleResult(attachment);
        }

        [HttpGet("[action]/{fileId}")]
        public async Task<ActionResult<GetFileDetailDto>> GetApplicatedFilesInfoAsync(int fileId)
        {
            var attachmentsInfo = await Mediator.Send(new GetApplicatedAttachmentQuery(fileId));

            return HandleResult(attachmentsInfo);
        }

        /// <summary>
        /// Writes file in HD, in db there is a link to disc location
        /// </summary>
        /// <param name="applicationId"></param>
        /// <param name="formFile"></param>
        /// <returns></returns>
        [HttpPost("[action]/{applicationId}")]
        public async Task<ActionResult> AddFileAsync(int applicationId, IFormFile formFile)
        {
            return HandleResult(await Mediator.Send(new AddFileToApplicationCommand { ApplicationId = applicationId, 
                File = formFile }));
        }

        [HttpPost("[action]/{applicationId}")]
        public async Task<ActionResult> AddSmallFileAsync(int applicationId, IFormFile formFile)
        {
            return HandleResult(await Mediator.Send(new AddSmallFileToApplicationCommand
            {
                ApplicationId = applicationId,
                FormFile = formFile
            }));
        }

        [HttpDelete("[action]/{fileId}")]
        public async Task<ActionResult> DeleteFileAsync(int fileId)
        {
            return HandleResult(await Mediator.Send(new DeleteFileCommand { AttachmentId = fileId }));
        }

        [HttpDelete("[action]/{fileId}")]
        public async Task<ActionResult> DeleteSmallFileAsync(int fileId)
        {
            return HandleResult(await Mediator.Send(new DeleteSmallFileCommand { AttachmentId = fileId }));
        }

    }
}
