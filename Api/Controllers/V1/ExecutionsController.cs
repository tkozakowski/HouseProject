using Application.Executions.Command.Add;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Api.Controllers.V1
{
    public class ExecutionsController : BaseApiController
    {

        [HttpPost]
        public async Task<IActionResult> AddExecution(AddExecutionDto executionDto)
        {
            return HandleResult(await Mediator.Send(new AddExecutionCommand { AddExecutionDto = executionDto }));
        }

    }
}
