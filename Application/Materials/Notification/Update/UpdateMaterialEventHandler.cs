using Application.Executions.Command.Update;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Materials.Notification.Update
{
    public class UpdateMaterialEventHandler : INotificationHandler<UpdateMaterialEvent>
    {
        private readonly IMediator _mediator;

        public UpdateMaterialEventHandler(IMediator mediator)
        {
            _mediator = mediator;
        }

        public async Task Handle(UpdateMaterialEvent notification, CancellationToken cancellationToken)
        {
            await _mediator.Send(new UpdateExecutionCostCommand { ExecutionId = notification.MaterialId });
        }
    }
}
