using Application.Collaborators.Create;
using Application.Customers.GetAll;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Web.API.Controllers;

[Route("Collaborators")]
public class  Collaborators : ApiController
{

    private readonly ISender _mediator;

    public  Collaborators(ISender mediator)
    {
        _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] CreateCollaboratorCommand command)
    {
        var createCustomerResult = await _mediator.Send(command);

        return createCustomerResult.Match(
            customer => Ok(),
            errors => Problem(errors)

        );

    }

     [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var result = await _mediator.Send(new GetAllCustomersQuery());

        if (result.IsError)
        {
            return BadRequest(result.Errors);
        }

        
        return Ok(result.Value);
    }
}