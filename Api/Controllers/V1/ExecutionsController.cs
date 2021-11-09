using Application.Executions.Command.Add;
using Application.Executions.Command.Delete;
using Application.Executions.Command.Update;
using Application.Executions.Query.GetAll;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Api.Controllers.V1
{
    public class ExecutionsController : BaseApiController
    {

        [HttpGet]
        public async Task<ActionResult<IEnumerable<GetExecutionsDto>>> GetAllAsync()
        {
            var result = await Mediator.Send(new GetExecutionsQuery());

            return HandleResult<IEnumerable<GetExecutionsDto>> (result);
        }

        [HttpPost]
        public async Task<IActionResult> AddExecutionAsync(AddExecutionDto executionDto)
        {
            return HandleResult(await Mediator.Send(new AddExecutionCommand { AddExecutionDto = executionDto }));
        }

        [HttpPut]
        public async Task<IActionResult> UpdateExecutionAsync(int id)
        {
            return HandleResult(await Mediator.Send(new UpdateExecutionCostCommand { ExecutionId = id }));
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteExecutionAsync(int id)
        {
            return HandleResult(await Mediator.Send(new DeleteExecutionCommand { ExecutionId = id }));
        }
    }
}
