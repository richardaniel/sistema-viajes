using ErrorOr;
using MediatR;

namespace Application.Transporters.Create;

public record CreateTransporterCommand(
    string Name,
    decimal RatePerKm) : IRequest<ErrorOr<Unit>>;
