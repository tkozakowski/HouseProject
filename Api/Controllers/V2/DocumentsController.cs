using Api.Controllers;
using Application.CosmosDocuments.Command.Create;
using Application.CosmosDocuments.Command.Remove;
using Application.CosmosDocuments.Command.Update;
using Application.CosmosDocuments.Query.GetDetail;
using Application.Queries.CosmosDocuments;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;


/// <summary>
/// NoSql CosmosDb
/// </summary>
namespace Api.V2.Controllers
{
    [ApiExplorerSettings(IgnoreApi = true)]
    [ApiVersion("2.0")]
    public class DocumentsController : BaseApiController
    {

        [HttpGet]
        public async Task<ActionResult<List<GetCosmosDocumentDto>>> GetDocuments()
        {
            return HandleResult(await Mediator.Send(new GetCosmosDocumentListQuery()));
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<GetCosmosDocumentDto>> GetDocument(string id)
        {
            return HandleResult(await Mediator.Send(new GetCosmosDocumentByIdQuery(id)));
        }


        [HttpPost]
        public async Task<ActionResult> CreateDocument([FromBody] CreateCosmosDocumentDto documentDto)
        {
            return HandleResult(await Mediator.Send(new InsertCosmosDocumentCommand { CosmosDocument = documentDto }));
        }


        [HttpPut]
        public async Task<IActionResult> UpdateDocument([FromBody] UpdateCosmosDocumentDto documentDto)
        {
            return HandleResult(await Mediator.Send(new UpdateCosmosDocumentCommand { UpdateCosmosDocumentDto = documentDto }));
        }


        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDocument(string id)
        {
            return HandleResult(await Mediator.Send(new RemoveCosmosDocumentCommand { Id = id }));
        }
    }
}
