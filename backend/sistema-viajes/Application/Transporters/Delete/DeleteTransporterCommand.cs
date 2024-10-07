using ErrorOr;
using MediatR;

namespace Application.Transporters.Delete;

public record DeleteTransporterCommand(Guid TransporterId) : IRequest<ErrorOr<Unit>>;
