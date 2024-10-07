
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;

namespace Web.API.Controllers;

public class ErrorsControllers : ControllerBase 
{
    [ApiExplorerSettings(IgnoreApi = true)]
    [Route("/error")]

    public IActionResult Error(){

        Exception? exception =HttpContext.Features.Get<IExceptionHandlerFeature>()?.Error;

        return Problem();
    }
}