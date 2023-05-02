using FansoftEcommerce.Application.Common;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;

namespace FansoftEcommerce.Api.Controllers;

public class ErrorsController : ControllerBase
{

    [Route("/error")]
    [ApiExplorerSettings(IgnoreApi=true)]
    public IActionResult Error()
    {
        var ex = HttpContext.Features.Get<IExceptionHandlerFeature>()?.Error;
        int statusCode = 500;
        if (ex is ValidationBehaviorException)
        {
            statusCode = 400;
        }
        // https://code-maze.com/using-the-problemdetails-class-in-asp-net-core-web-api/
        var problemResponse =  Problem(
            title: ex?.Message,
            statusCode:statusCode);
        
        return problemResponse;
    }
}