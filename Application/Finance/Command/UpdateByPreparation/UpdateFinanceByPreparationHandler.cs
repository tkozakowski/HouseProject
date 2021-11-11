using Application.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Finance.Command.UpdateByPreparation
{
    public class UpdateFinanceByPreparationHandler : IRequestHandler<UpdateFinanceByPreparationCommand, Unit>
    {
        private readonly IHouseProjectDbContext _houseProjectDbContext;

        public UpdateFinanceByPreparationHandler(IHouseProjectDbContext houseProjectDbContext)
        {
            _houseProjectDbContext = houseProjectDbContext;
        }

        public async Task<Unit> Handle(UpdateFinanceByPreparationCommand request, CancellationToken cancellationToken)
        {
            var finance = await _houseProjectDbContext.Finances.FirstOrDefaultAsync();
            if (finance is null) return await Task.FromResult(Unit.Value);

            var totalPreparationsCosts = await _houseProjectDbContext.Preparations?.SumAsync(x => x.Cost);

            finance.PreparationsCost = totalPreparationsCosts;
            finance.TotalCost = finance.DocumentsCost + finance.ExecutionsCost + finance.PreparationsCost + finance.ProjectsCost;

            await _houseProjectDbContext.SaveChangesAsync();

            return await Task.FromResult(Unit.Value);
        }
    }
}
