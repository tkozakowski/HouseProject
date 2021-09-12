using HouseProject.Application.Core;
using HouseProject.Domain.Entities;
using MediatR;
using System.Collections.Generic;

namespace HouseProject.Application.Queries.LoanTranches
{
    public class GetAllLoanTranchesQuery: IRequest<Result<List<LoanTranche>>>
    {
    }
}
