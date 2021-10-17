using Api.Controllers;
using Application.Dto.LoanTranche;
using Application.LoanTranches.Command.Remove;
using Application.LoanTranches.Query.GetAll;
using Application.LoanTranches.Query.GetDetail;
using Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Api.V1.Controllers
{
    public class LoanTranchesController: BaseApiController
    {
        [HttpGet]
        public async Task<ActionResult<List<LoanTranche>>> GetAllLoanTranche()
        {
            return HandleResult<List<LoanTrancheDto>>(await Mediator.Send(new GetAllLoanTranchesQuery()));
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<LoanTrancheDto>> GetLoanTrancheById(int id)
        {
            return HandleResult<LoanTrancheDto>(await Mediator.Send(new GetLoanTrancheByIdQuery { Id = id}));
        }

        //[HttpPost]
        //public async Task<ActionResult> AddOrUpdateLoanTranche([FromBody] LoanTrancheDto loanTranche)
        //{
        //    return HandleResult<Unit>(await Mediator.Send(new AddOrUpdateLoanTrancheCommand { LoanTrancheDto = loanTranche}));
        //}

        [HttpDelete("{id}")]
        public async Task<ActionResult> RemoveLoanTranche(int id)
        {
            return HandleResult<Unit>(await Mediator.Send(new RemoveLoanTrancheCommand { Id = id }));
        }
    }
}
