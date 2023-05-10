using apilab1.models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace apilab1.filters
{
    public class Typefilter:ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            Cars? cars = context.ActionArguments["car"] as Cars;
            var cartypes="electricty,gas,hyprid,diesel".Split(',');
            if(cars==null || !cartypes.Contains(cars.type))
            {
                context.ModelState.AddModelError("type", "wrong type");
                context.Result = new BadRequestObjectResult(context.ModelState);
            }
        }

    }
}
