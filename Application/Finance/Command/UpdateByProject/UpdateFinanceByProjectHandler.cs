using Application.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Finance.Command.UpdateByProject
{
    class UpdateFinanceByProjectHandler : IRequestHandler<UpdateFinanceByProjectCommand, Unit>
    {
        private readonly IHouseProjectDbContext _houseProjectDbContext;

        public UpdateFinanceByProjectHandler(IHouseProjectDbContext houseProjectDbContext)
        {
            _houseProjectDbContext = houseProjectDbContext;
        }

        public async Task<Unit> Handle(UpdateFinanceByProjectCommand request, CancellationToken cancellationToken)
        {
            var finance = await _houseProjectDbContext.Finances.FirstOrDefaultAsync();

            var totalProjectCosts = await _houseProjectDbContext.Projects?.SumAsync(x => x.Cost) ?? 0M;

            finance.ProjectsCost = totalProjectCosts;
            finance.TotalCost = finance.DocumentsCost + finance.ExecutionsCost + finance.PreparationsCost + finance.ProjectsCost;

            await _houseProjectDbContext.SaveChangesAsync();

            return await Task.FromResult(Unit.Value);
        }
    }
}
