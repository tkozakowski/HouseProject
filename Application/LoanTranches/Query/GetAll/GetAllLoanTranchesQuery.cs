using Application.Core;
using Application.Dto.LoanTranche;
using MediatR;
using System.Collections.Generic;

namespace Application.LoanTranches.Query.GetAll
{
    public class GetAllLoanTranchesQuery: IRequest<Result<List<LoanTrancheDto>>>
    {
    }
}
