using Application.Core;
using Application.Interfaces;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Application.PaymentTypes.Query.GetAll
{
    public class PaymentTypesHandler : IRequestHandler<GetPaymentTypesQuery, Result<IEnumerable<PaymentTypeDto>>>
    {
        public readonly IHouseProjectDbContext _houseProjectDbContext;
        public readonly IMapper _mapper;

        public PaymentTypesHandler(IHouseProjectDbContext houseProjectDbContext, IMapper mapper)
        {
            _houseProjectDbContext = houseProjectDbContext;
            _mapper = mapper;
        }

        public async Task<Result<IEnumerable<PaymentTypeDto>>> Handle(GetPaymentTypesQuery request, CancellationToken cancellationToken)
        {
            var result = await _houseProjectDbContext.PaymentTypes.ProjectTo<PaymentTypeDto>(_mapper.ConfigurationProvider).ToListAsync();

            return Result<IEnumerable<PaymentTypeDto>>.Success(result);
        }
    }
}
