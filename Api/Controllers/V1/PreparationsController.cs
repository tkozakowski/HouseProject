using Application.Preparations.Command.Add;
using Application.Preparations.Query.GetAll;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Api.Controllers.V1
{
    public class PreparationsController : BaseApiController
    {
        [HttpGet]
        public async Task<ActionResult<IEnumerable<GetPreparationsDto>>> GetPreparationsAsync()
        {
            return HandleResult(await Mediator.Send(new GetPreparationsQuery()));
        }

        [HttpPost]
        public async Task<IActionResult> AddAsync(AddPreparationCommand command)
        {
            var result = await Mediator.Send(command);
            return HandleResult(result);
        }
    }
}
