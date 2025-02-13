using Application.Trips.GetAll;
using Domain.Trips;
using ErrorOr;
using MediatR;

namespace Application.Trips.GetAll;

internal sealed class GetAllTripsQueryHandler : IRequestHandler<GetAllTripsQuery, ErrorOr<List<Trip>>>
{
    private readonly ITripRepository _tripRepository;

    public GetAllTripsQueryHandler(ITripRepository tripRepository)
    {
        _tripRepository = tripRepository ?? throw new ArgumentNullException(nameof(tripRepository));
    }

    public async Task<ErrorOr<List<Trip>>> Handle(GetAllTripsQuery request, CancellationToken cancellationToken)
    {
        try
        {
            var trips = await _tripRepository.GetAllAsync();
            return trips;
        }
        catch (Exception ex)
        {
            return Error.Failure("GetAllTrips.Failure", ex.Message);
        }
    }
}
