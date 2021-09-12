using HouseProject.API.Controllers;
using HouseProject.Application.Command.Documents;
using HouseProject.Application.Dto;
using HouseProject.Application.Queries.Documents;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HouseProject.Api.Controllers
{

    public class DocumentController : BaseApiController
    {

        [HttpGet]
        public async Task<ActionResult<List<DocumentDto>>> GetDocuments()
        {
            return HandleResult(await Mediator.Send(new GetDocumentListQuery()));
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<DocumentDto>> GetDocument(int id)
        {
            return HandleResult(await Mediator.Send(new GetDocumentByIdQuery(id)));
        }


        [HttpPost]
        public async Task<ActionResult> CreateDocument([FromBody] DocumentDto documentDto)
        {
            return HandleResult(await Mediator.Send(new InsertDocumentCommand(documentDto)));
        }


        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateDocument(int id, [FromBody] DocumentDto documentDto)
        {
            return HandleResult(await Mediator.Send(new UpdateDocumentCommand { DocumentDto = documentDto, Id = id }));
        }


        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDocument(int id)
        {
            return HandleResult(await Mediator.Send(new RemoveDocumentCommand { Id = id }));
        }
    }
}
