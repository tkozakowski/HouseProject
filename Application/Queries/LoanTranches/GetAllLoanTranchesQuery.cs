using Application.Core;
using Application.Dto.LoanTranche;
using MediatR;
using System.Collections.Generic;

namespace Application.Queries.LoanTranches
{
    public class GetAllLoanTranchesQuery: IRequest<Response<List<LoanTrancheDto>>>
    {
    }
}
