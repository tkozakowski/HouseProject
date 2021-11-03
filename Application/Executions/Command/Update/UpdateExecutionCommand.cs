using Application.Core;
using MediatR;

namespace Application.Executions.Command.Update
{
    public class UpdateExecutionCommand: IRequest<Result<Unit>>
    {
        public int ExecutionId { get; set; }
    }
}
