using Api.Controllers;
using Application.Core.Attributes;
using Application.Core.Paginations;
using Application.Core.Sortings;
using Application.Document.Query.GetDocuments;
using Application.Documents.Command.CreateDocument;
using Application.Documents.Command.RemoveDocument;
using Application.Documents.Command.UpdateDocument;
using Application.Documents.Query.Details;
using Application.Documents.Query.GetDocumentDetails;
using Infrastructure.Identity;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

/// <summary>
/// SQL
/// </summary>
namespace Api.V1.Controllers
{
    //[ApiExplorerSettings(IgnoreApi = true)]
    [ApiVersion("1.0")]
    [Authorize]
    public class DocumentsController : BaseApiController
    {
        public DocumentsController() { }


        /// <summary>
        /// An example of using pagination, sorting and filtering
        /// </summary>
        /// <param name="paginationFilters"></param>
        /// <param name="sortingFilter"></param>
        /// <param name="filterBy"></param>
        /// <returns></returns>
        [HttpGet]
        //[Authorize(Roles = UserRoles.UserOrUserRO)]
        [AllowAnonymous]
        public async Task<ActionResult<List<GetDocumentDto>>> GetDocumentsAsync([FromQuery] PaginationFilter paginationFilters,
            [FromQuery] SortingFilter sortingFilter, [FromQuery] string filterBy = "")
        {
            var validPaginationFilter = new PaginationFilter(paginationFilters.PageNumber, paginationFilters.PageSize);

            var validSortingFilter = new SortingFilter(sortingFilter.SortField, sortingFilter.Ascending);

            return HandleResult(await Mediator.Send(new GetDocumentListQuery(validPaginationFilter, validSortingFilter, filterBy)));
        }

        /// <summary>
        /// Returns a list of fields that we can sort by
        /// </summary>
        /// <returns></returns>
        [HttpGet("[action]")]
        [Authorize(Roles = UserRoles.UserOrUserRO)]
        public IActionResult GetSortFields()
        {
            return Ok(SortingHelper.GetSortFields().Select(x => x.Key));
        }

        /// <summary>
        /// Retrieves all documents in OData protocol
        /// </summary>
        /// <returns></returns>
        //[HttpGet("[action]")]
        //[Authorize(Roles = UserRoles.UserOrUserRO)]
        //[EnableQuery]
        //public IQueryable<DocumentDto> GetAll()
        //{

        //}


        [HttpGet("{id}")]
        [Authorize(Roles = UserRoles.UserOrUserRO)]
        public async Task<ActionResult<DocumentDetailsDto>> GetDocumentAsync(int id)
        {
            return HandleResult(await Mediator.Send(new GetDocumentDetailQuery(id)));
        }


        [HttpPost]
        [ValidateFilterAttributes]
        [Authorize(Roles = UserRoles.User)]
        public async Task<IActionResult> CreateDocument([FromBody] CreateDocumentDto documentDto)
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

            return HandleResult(await Mediator.Send(new CreateDocumentCommand { CreateDocumentDto = documentDto, UserId = userId }));
        }


        [HttpPut("{id}")]
        [Authorize(Roles = UserRoles.User)]
        public async Task<IActionResult> UpdateDocument(int id, [FromBody] UpdateDocumentDto documentDto)
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            return HandleResult(await Mediator.Send(new UpdateDocumentCommand { UpdateDocumentDto = documentDto, Id = id, UserId = userId }));
        }


        [HttpDelete("{id}")]
        [Authorize(Roles = UserRoles.User)]
        public async Task<IActionResult> DeleteDocument(int id)
        {
            return HandleResult(await Mediator.Send(new RemoveDocumentCommand { Id = id }));
        }
    }
}
