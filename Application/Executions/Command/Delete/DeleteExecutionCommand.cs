using Application.Core;
using MediatR;

namespace Application.Executions.Command.Delete
{
    public class DeleteExecutionCommand: IRequest<Result<Unit>>
    {
        public int ExecutionId { get; set; }
    }
}
