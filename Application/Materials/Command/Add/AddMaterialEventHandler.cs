using Application.Executions.Command.Update;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Materials.Command.Add
{
    public class AddMaterialEventHandler : INotificationHandler<AddMaterialEvent>
    {
        private readonly IMediator _mediator;

        public AddMaterialEventHandler(IMediator mediator)
        {
            _mediator = mediator;
        }

        public async Task Handle(AddMaterialEvent notification, CancellationToken cancellationToken)
        {
            await _mediator.Send(new UpdateExecutionCommand { ExecutionId = notification.ExecutionId });
        }
    }
}
