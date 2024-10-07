using ErrorOr;
using MediatR;

namespace Application.CollaboratorBranches.Create;

public record CreateCollaboratorBranchCommand(
    Guid CustomerId,
    Guid BranchId,
    int DistanceKm) : IRequest<ErrorOr<Unit>>;
