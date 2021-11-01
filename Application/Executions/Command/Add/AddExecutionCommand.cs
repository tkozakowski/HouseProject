using Application.Core;
using MediatR;

namespace Application.Executions.Command.Add
{
    public class AddExecutionCommand: IRequest<Result<Unit>>
    {
        public AddExecutionDto AddExecutionDto { get; set; }
    }
}
