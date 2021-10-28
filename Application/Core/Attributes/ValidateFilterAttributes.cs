using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Linq;

namespace Application.Core.Attributes
{
    public class ValidateFilterAttributes : ResultFilterAttribute
    {
        public override void OnResultExecuting(ResultExecutingContext context)
        {
            base.OnResultExecuting(context);

            if (!context.ModelState.IsValid)
            {
                var entry = context.ModelState.Values.FirstOrDefault();

                context.Result = new BadRequestObjectResult(new Result<bool>
                { 
                    IsSuccess = false, 
                    Errors = entry.Errors.Select(x => x.ErrorMessage),                    
                });
            }
        }
    }
}
