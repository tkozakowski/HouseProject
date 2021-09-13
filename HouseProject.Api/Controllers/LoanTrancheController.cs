using HouseProject.API.Controllers;
using HouseProject.Application.Command.LoanTranches;
using HouseProject.Application.Queries.LoanTranches;
using HouseProject.Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HouseProject.Api.Controllers
{
    public class LoanTrancheController: BaseApiController
    {
        [HttpGet]
        public async Task<ActionResult<List<LoanTranche>>> GetAllLoanTranche()
        {
            return HandleResult<List<LoanTranche>>(await Mediator.Send(new GetAllLoanTranchesQuery()));
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<LoanTranche>> GetLoanTrancheById(int id)
        {
            return HandleResult<LoanTranche>(await Mediator.Send(new GetLoanTrancheByIdQuery { Id = id}));
        }

        [HttpPost]
        public async Task<ActionResult> AddOrUpdateLoanTranche([FromBody] LoanTranche loanTranche)
        {
            return HandleResult<Unit>(await Mediator.Send(new AddOrUpdateLoanTrancheCommand { LoanTranche = loanTranche}));
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> RemoveLoanTranche(int id)
        {
            return HandleResult<Unit>(await Mediator.Send(new RemoveLoanTrancheCommand { Id = id }));
        }
    }
}
