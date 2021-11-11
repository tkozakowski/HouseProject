using Application.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Finance.Command.UpdateByDocument
{
    public class UpdateFinanceByDocumentHandler : IRequestHandler<UpdateFinanceByDocumentCommand, Unit>
    {
        private readonly IHouseProjectDbContext _houseProjectDbContext;

        public UpdateFinanceByDocumentHandler(IHouseProjectDbContext houseProjectDbContext)
        {
            _houseProjectDbContext = houseProjectDbContext;
        }

        public async Task<Unit> Handle(UpdateFinanceByDocumentCommand request, CancellationToken cancellationToken)
        {
            var finance = await _houseProjectDbContext.Finances.FirstOrDefaultAsync();
            if (finance is null) return await Task.FromResult(Unit.Value);

            var totalDocumentsCosts = await _houseProjectDbContext.Documents?.SumAsync(x => x.Cost);
            if (!totalDocumentsCosts.HasValue) return Unit.Value;

            finance.DocumentsCost = totalDocumentsCosts;
            finance.TotalCost = finance.DocumentsCost + finance.ExecutionsCost + finance.PreparationsCost + finance.ProjectsCost;

            await _houseProjectDbContext.SaveChangesAsync();

            return await Task.FromResult(Unit.Value);
        }
    }
}
