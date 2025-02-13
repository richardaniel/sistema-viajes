using MediatR;
using Microsoft.AspNetCore.Mvc;
using Application.Trips.GetAll;

namespace Web.API.Controllers
{

    [Route("Trips")]
    public class Trips :ApiController
    {

        private readonly ISender _mediator;

        public Trips(ISender mediator)
        {
            _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
        }

        [HttpGet]
        public async Task<IActionResult> GetAllTrips()
        {
            var tripsResult =await _mediator.Send(new GetAllTripsQuery());

            if (tripsResult.IsError)
            {
                return BadRequest(tripsResult.Errors);
            }

            return Ok(tripsResult);
           
        } 

    }
}
