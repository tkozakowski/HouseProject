using Application.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Finance.Command.UpdateByExecution
{
    public class UpdateByExecutionHandler : IRequestHandler<UpdateByExecutionCommand, Unit>
    {
        private readonly IHouseProjectDbContext _houseProjectDbContext;

        public UpdateByExecutionHandler(IHouseProjectDbContext houseProjectDbContext)
        {
            _houseProjectDbContext = houseProjectDbContext;
        }

        public async Task<Unit> Handle(UpdateByExecutionCommand request, CancellationToken cancellationToken)
        {
            var finance = await _houseProjectDbContext.Finances.FirstOrDefaultAsync();
            if (finance is null) return await Task.FromResult(Unit.Value);

            var totalExecutionsCosts = await _houseProjectDbContext.Executions?.SumAsync(x => x.CostPayed);
            if (!totalExecutionsCosts.HasValue) return Unit.Value;

            finance.ExecutionsCost = totalExecutionsCosts;
            finance.TotalCost = finance.DocumentsCost + finance.ExecutionsCost + finance.PreparationsCost + finance.ProjectsCost;

            await _houseProjectDbContext.SaveChangesAsync();

            return await Task.FromResult(Unit.Value);
        }
    }
}
