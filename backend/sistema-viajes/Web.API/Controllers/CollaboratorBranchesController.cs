
using Application.CollaboratorBranches.Create;
using Application.CollaboratorBranches.GetCustomerByBranchId;
using Domain.Branches;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Web.API.Controllers;

[Route("CollaboratorBranches")]
public class CollaboratorBranchesController : ApiController
{

    private readonly ISender _mediator;

    public CollaboratorBranchesController(ISender mediator)
    {
        _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
    }

    [HttpGet("branches/{branchId}/collaborators")]
    public async Task<IActionResult> GetCustomersForBranch([FromRoute] string branchId)
    {
        Guid branchIdGuid = Guid.Parse(branchId);
        var result = await _mediator.Send(new GetCustomersByBranchIdCommand(branchIdGuid));
        

        if (result.IsError)
        {
            return BadRequest(result.Errors);
        }
        return Ok(result.Value);
    }



    /* [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var result = await _mediator.Send(new GetAllBranchesCommand());

        if (result.IsError)
        {
            return BadRequest(result.Errors);
        }

        return Ok(result.Value);
    }*/

    [HttpPost]
    public async Task<IActionResult> CreateCollaboratorBranch([FromBody]CreateCollaboratorBranchCommand command)
    {
        var result = await _mediator.Send(command);
        if (result.IsError)
        {
        return BadRequest(result.Errors);
        }
        return Ok(result.Value);
    }

}