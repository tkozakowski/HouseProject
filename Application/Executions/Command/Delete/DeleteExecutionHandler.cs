using Application.Core;
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

        public DeleteExecutionHandler(IHouseProjectDbContext houseProjectDbContext)
        {
            _houseProjectDbContext = houseProjectDbContext;
        }

        public async Task<Result<Unit>> Handle(DeleteExecutionCommand request, CancellationToken cancellationToken)
        {
            var execution = await _houseProjectDbContext.Executions.FirstOrDefaultAsync(x => x.Id == request.ExecutionId);

            if (execution != null)
            {
                _houseProjectDbContext.Executions.Remove(execution);

                var materials = await _houseProjectDbContext.Materials?.Where(x => x.ExecutionId == request.ExecutionId)?.ToListAsync();
                materials.ForEach(x => x.ExecutionId = null);

                await _houseProjectDbContext.SaveChangesAsync();
            }

            var executionTotalCosts = await _houseProjectDbContext.Executions?.SumAsync(x => x.CostPayed) ?? 0M;

            var finance = await _houseProjectDbContext.Finances.FirstOrDefaultAsync();
            finance.ExecutionsCost = executionTotalCosts;

            await _houseProjectDbContext.SaveChangesAsync();


            return Result<Unit>.Success(Unit.Value);
        }
    }
}
