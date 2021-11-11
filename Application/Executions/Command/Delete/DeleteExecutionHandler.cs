using Application.Core;
using Application.Finance.Command.UpdateByExecution;
using Application.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Executions.Command.Delete
{
    public class DeleteExecutionHandler : IRequestHandler<DeleteExecutionCommand, Result<Unit>>
    {
        private readonly IHouseProjectDbContext _houseProjectDbContext;
        private readonly IMediator _mediator;

        public DeleteExecutionHandler(IHouseProjectDbContext houseProjectDbContext, IMediator mediator)
        {
            _houseProjectDbContext = houseProjectDbContext;
            _mediator = mediator;
        }

        public async Task<Result<Unit>> Handle(DeleteExecutionCommand request, CancellationToken cancellationToken)
        {
            var execution = await _houseProjectDbContext.Executions.FirstOrDefaultAsync(x => x.Id == request.ExecutionId);

            if (execution is null)
                return Result<Unit>.Failure($"Failed to remove execution with id {request.ExecutionId}");

            _houseProjectDbContext.Executions.Remove(execution);

            var materials = await _houseProjectDbContext.Materials?.Where(x => x.ExecutionId == request.ExecutionId)?.ToListAsync();
            if(materials != null && materials.Any())
                materials.ForEach(x => x.ExecutionId = null);

            await _houseProjectDbContext.SaveChangesAsync();

            await _mediator.Send(new UpdateFinanceByExecutionCommand());

            return Result<Unit>.Success(Unit.Value);
        }
    }
}
