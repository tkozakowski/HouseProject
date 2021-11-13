using Application.Attachments.Command.AddAttachment;
using Application.Attachments.Command.DeleteFromHD;
using Application.Attachments.Query.DownloadFile;
using Application.Attachments.Query.GetAttachmentInfo;
using Application.AttachmentsSmall.Command.Add;
using Application.AttachmentsSmall.Command.DeleteFromDb;
using Application.AttachmentsSmall.Query.GetAll;
using Application.AttachmentsSmall.Query.GetDetail;
using Application.Dto.Attachments;
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

        [HttpGet("[action]/{documentId}")]
        public async Task<ActionResult<IEnumerable<SmallFileDto>>> GetSmallFilesAsync(int documentId)
        {
            return HandleResult(await Mediator.Send(new GetSmallFilesQuery(documentId)));
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
        /// <param name="documentId"></param>
        /// <param name="formFile"></param>
        /// <returns></returns>
        [HttpPost("[action]/{documentId}")]
        public async Task<ActionResult> AddFileAsync(int documentId, IFormFile formFile)
        {
            return HandleResult(await Mediator.Send(new AddFileToDocumentCommand { DocumentId = documentId, 
                File = formFile }));
        }

        [HttpPost("[action]/{documentId}")]
        public async Task<ActionResult> AddSmallFileAsync(int documentId, IFormFile formFile)
        {
            return HandleResult(await Mediator.Send(new AddSmallFileToDocumentCommand
            {
                DocumentId = documentId,
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
