using Application.Customers.Create;
using Application.Customers.GetAll;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Web.API.Controllers;

[Route("Customers")]
public class Customers : ApiController
{

    private readonly ISender _mediator;

    public Customers(ISender mediator)
    {
        _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] CreateCustomerCommand command)
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
        var result = await _mediator.Send(new GetAllCustomersCommand());

        if (result.IsError)
        {
            return BadRequest(result.Errors);
        }

        
        return Ok(result.Value);
    }
}