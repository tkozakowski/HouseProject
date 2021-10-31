using Application.PaymentTypes.Query.GetAll;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Api.Controllers.V1
{
    [Route("api/[controller]")]
    public class PaymentTypesController : BaseApiController
    {
        public PaymentTypesController() { }



        [HttpGet]
        public async Task<ActionResult<IEnumerable<PaymentTypeDto>>> GetPaymentTypes()
        {
            var result = await Mediator.Send(new GetPaymentTypesQuery());

            return HandleResult<IEnumerable<PaymentTypeDto>>(result);
        }
    }
}
