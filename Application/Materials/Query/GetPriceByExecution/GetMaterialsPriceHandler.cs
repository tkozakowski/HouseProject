using Application.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Materials.Query.GetPriceByExecution
{
    public class GetMaterialsPriceHandler : IRequestHandler<GetMaterialsPriceCommand, GetMaterialsPriceDto>
    {
        private readonly IHouseProjectDbContext _houseProjectDbContext;

        public GetMaterialsPriceHandler(IHouseProjectDbContext houseProjectDbContext)
        {
            _houseProjectDbContext = houseProjectDbContext;
        }

        public async Task<GetMaterialsPriceDto> Handle(GetMaterialsPriceCommand request, CancellationToken cancellationToken)
        {
            var materials = await _houseProjectDbContext.Materials.Where(x => x.ExecutionId == request.executionId).ToListAsync();

            var calculatedPrice = materials.Select(x => new GetMaterialsPriceDto
                {
                    Price = x.PriceItem.Value * x.Amount
                })
                .Sum(x => x.Price);

            return new GetMaterialsPriceDto { Price = calculatedPrice };

        }

    }
}
