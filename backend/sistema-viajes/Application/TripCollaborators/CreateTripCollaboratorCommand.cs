using ErrorOr;
using MediatR;

namespace Application.TripCollaborators.Create;

public record CreateTripCollaboratorCommand(
    int TripId,
    int UserId,
    decimal DistanceKm,
    decimal Cost) : IRequest<ErrorOr<Unit>>;
