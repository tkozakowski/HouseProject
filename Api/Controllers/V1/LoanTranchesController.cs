using Api.Controllers;
using Application.Dto.LoanTranche.Query;
using Application.LoanTranches.Command.Add;
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
    public class LoanTranchesController : BaseApiController
    {
        [HttpGet]
        public async Task<ActionResult<List<LoanTranche>>> GetAllLoanTrancheAsync()
        {
            return HandleResult<IEnumerable<LoanTrancheDto>>(await Mediator.Send(new GetAllLoanTranchesQuery()));
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<LoanTrancheDto>> GetLoanTrancheAsync(int id)
        {
            return HandleResult<LoanTrancheDto>(await Mediator.Send(new GetLoanTrancheByIdQuery { Id = id }));
        }

        [HttpPost]
        public async Task<ActionResult> AddLoanTrancheAsync([FromBody] AddLoanTrancheCommand request)
        {
            return HandleResult<Unit>(await Mediator.Send(request));
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> RemoveLoanTrancheAsync(int id)
        {
            return HandleResult<Unit>(await Mediator.Send(new RemoveLoanTrancheCommand { Id = id }));
        }
    }
}
