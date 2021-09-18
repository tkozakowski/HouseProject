using Application.Core;
using Domain.Entities;
using MediatR;
using System.Collections.Generic;

namespace Application.Queries.LoanTranches
{
    public class GetAllLoanTranchesQuery: IRequest<Result<List<LoanTranche>>>
    {
    }
}
