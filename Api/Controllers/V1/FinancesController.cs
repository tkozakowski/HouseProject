using Application.Finance.Query.GetDetail;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Api.Controllers.V1
{
    public class FinancesController : BaseApiController
    {
        [HttpGet]
        public async Task<ActionResult<GetFinanceDto>> GetFinanceDetailAsync()
        {
            var result = await Mediator.Send(new GetFinanceDetailQuery());
            return HandleResult(result);
        }
    }
}
