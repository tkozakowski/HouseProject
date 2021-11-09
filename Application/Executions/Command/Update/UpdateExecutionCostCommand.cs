using Application.Core;
using MediatR;

namespace Application.Executions.Command.Update
{
    public class UpdateExecutionCostCommand: IRequest<Result<Unit>>
    {
        public int ExecutionId { get; set; }
    }
}
