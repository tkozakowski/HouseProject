using Application.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Finance.Command.UpdateByPreparation
{
    public class UpdateByPreparationHandler : IRequestHandler<UpdateByPreparationCommand, Unit>
    {
        private readonly IHouseProjectDbContext _houseProjectDbContext;

        public UpdateByPreparationHandler(IHouseProjectDbContext houseProjectDbContext)
        {
            _houseProjectDbContext = houseProjectDbContext;
        }

        public async Task<Unit> Handle(UpdateByPreparationCommand request, CancellationToken cancellationToken)
        {
            var finance = await _houseProjectDbContext.Finances.FirstOrDefaultAsync();
            if (finance is null) return await Task.FromResult(Unit.Value);

            var totalPreparationsCosts = await _houseProjectDbContext.Preparations?.SumAsync(x => x.Cost);

            finance.PreparationsCost = totalPreparationsCosts;

            await _houseProjectDbContext.SaveChangesAsync();

            return await Task.FromResult(Unit.Value);
        }
    }
}
