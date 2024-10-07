using Application.Trips.GetById;
using Domain.Trips;
using ErrorOr;
using MediatR;

namespace Application.Trips.GetById;

internal sealed class GetTripByIdQueryHandler : IRequestHandler<GetTripByIdQuery, ErrorOr<Trip>>
{
    private readonly ITripRepository _tripRepository;

    public GetTripByIdQueryHandler(ITripRepository tripRepository)
    {
        _tripRepository = tripRepository ?? throw new ArgumentNullException(nameof(tripRepository));
    }

    public async Task<ErrorOr<Trip>> Handle(GetTripByIdQuery request, CancellationToken cancellationToken)
    {
        var trip = await _tripRepository.GetByIdAsync(new TripId(request.TripId));

        return trip is not null ? trip : Error.NotFound("Trip.NotFound", "Trip not found");
    }
}
