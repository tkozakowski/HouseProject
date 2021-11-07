using Application.Core;
using Application.Dto.LoanTranche.Query;
using MediatR;
using System.Collections.Generic;

namespace Application.LoanTranches.Query.GetAll
{
    public record GetAllLoanTranchesQuery: IRequest<Result<IEnumerable<LoanTrancheDto>>>
    {
    }
}
