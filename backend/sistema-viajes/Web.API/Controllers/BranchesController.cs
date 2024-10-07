
using Application.Branches.Create;
using Application.Branches.GetAll;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Web.API.Controllers;

[Route("Branches")]
public class Branches : ApiController
{

    private readonly ISender _mediator;

    public Branches(ISender mediator)
    {
        _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] CreateBranchCommand command)
    {
        var createBranchResult = await _mediator.Send(command);

        return createBranchResult.Match(
            branch => Ok(),
            errors => Problem(errors)

        );

    }

     [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var result = await _mediator.Send(new GetAllBranchesCommand());

        if (result.IsError)
        {
            return BadRequest(result.Errors);
        }
        return Ok(result.Value);
    }
}