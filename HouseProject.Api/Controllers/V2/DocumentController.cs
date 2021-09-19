using Api.Controllers;
using Application.Command.CosmosDocuments;
using Application.Dto.Cosmos;
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
    public class DocumentController : BaseApiController
    {

        [HttpGet]
        public async Task<ActionResult<List<CosmosDocumentDto>>> GetDocuments()
        {
            return HandleResult(await Mediator.Send(new GetCosmosDocumentListQuery()));
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<CosmosDocumentDto>> GetDocument(string id)
        {
            return HandleResult(await Mediator.Send(new GetCosmosDocumentByIdQuery { Id = id}));
        }


        [HttpPost]
        public async Task<ActionResult> CreateDocument([FromBody] CreateCosmosDocumentDto documentDto)
        {
            return HandleResult(await Mediator.Send(new InsertCosmosDocumentCommand(documentDto)));
        }


        [HttpPut]
        public async Task<IActionResult> UpdateDocument([FromBody] CosmosDocumentDto documentDto)
        {
            return HandleResult(await Mediator.Send(new UpdateCosmosDocumentCommand { CosmosDocumentDto = documentDto }));
        }


        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDocument(string id)
        {
            return HandleResult(await Mediator.Send(new RemoveCosmosDocumentCommand { Id = id }));
        }
    }
}
