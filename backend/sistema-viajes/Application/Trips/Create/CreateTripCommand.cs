using ErrorOr;
using MediatR;

namespace Application.Trips.Create;

public record CreateTripCommand(
    Guid BranchId,
    Guid TransporterId,
    DateTime TripDate,
    List<Guid> CustomerId,
    decimal TotalDistance) : IRequest<ErrorOr<Unit>>;
