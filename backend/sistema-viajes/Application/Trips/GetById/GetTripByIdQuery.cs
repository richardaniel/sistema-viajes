using ErrorOr;
using MediatR;
using Domain.Trips;

namespace Application.Trips.GetById;

public record GetTripByIdQuery(Guid TripId) : IRequest<ErrorOr<Trip>>;
