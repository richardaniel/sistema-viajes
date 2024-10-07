using ErrorOr;
using MediatR;

namespace Application.Branches.Delete;

public record DeleteBranchCommand(Guid BranchId) : IRequest<ErrorOr<Unit>>;
