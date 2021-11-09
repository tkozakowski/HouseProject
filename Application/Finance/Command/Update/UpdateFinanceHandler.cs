using Application.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Finance.Command.Update
{
    public class UpdateFinanceHandler : IRequestHandler<UpdateFinanceCommand, Unit>
    {
        private readonly IHouseProjectDbContext _houseProjectDbContext;

        public UpdateFinanceHandler(IHouseProjectDbContext houseProjectDbContext)
        {
            _houseProjectDbContext = houseProjectDbContext;
        }

        public async Task<Unit> Handle(UpdateFinanceCommand request, CancellationToken cancellationToken)
        {

            var finance = await _houseProjectDbContext.Finances.FirstOrDefaultAsync();
            if (finance is null) finance = new Domain.Entities.Finance();
            await _houseProjectDbContext.Finances.AddAsync(finance);

            var totalProjectCosts = _houseProjectDbContext.Projects?.SumAsync(x => x.Cost);
            var totalPreparationsCosts = _houseProjectDbContext.Preparations?.SumAsync(x => x.Cost);
            var totalDocumentsCosts = _houseProjectDbContext.Documents?.SumAsync(x => x.Cost);
            var totalExecutionsCosts = _houseProjectDbContext.Executions?.SumAsync(x => x.CostPayed);

            await Task.WhenAll(totalPreparationsCosts, totalPreparationsCosts, totalDocumentsCosts, totalExecutionsCosts);


            finance.ProjectsCost = totalProjectCosts.Result ?? 0;
            finance.PreparationsCost = totalPreparationsCosts.Result;
            finance.DocumentsCost = totalDocumentsCosts.Result ?? 0;
            finance.ExecutionsCost = totalExecutionsCosts.Result ?? 0;

            await _houseProjectDbContext.SaveChangesAsync();

            return Unit.Value;
        }
    }
}
