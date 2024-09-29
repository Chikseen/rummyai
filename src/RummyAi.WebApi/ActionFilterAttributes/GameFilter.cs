using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Primitives;
using RummyAi.Domain.Features.GameDto;

namespace RummyAi.WebApi.ActionFilterAttributes;

public class GameFilter : ActionFilterAttribute
{
    public override void OnActionExecuting(ActionExecutingContext context)
    {
        StringValues queryStringValue = context.HttpContext.Request.Query[nameof(GameId)];

        if (queryStringValue == StringValues.Empty)
        {
            context.Result = new BadRequestObjectResult("No GameId");
            return;
        }

        if (!Guid.TryParse(queryStringValue, out Guid _))
        {
            context.Result = new BadRequestObjectResult("Invlaid GameId");
            return;
        }
    }
}