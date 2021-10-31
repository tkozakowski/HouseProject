using Application.Core;
using MediatR;
using System.Collections.Generic;

namespace Application.PaymentTypes.Query.GetAll
{
    public record GetPaymentTypesQuery: IRequest<Result<IEnumerable<PaymentTypeDto>>>
    {
    }
}
