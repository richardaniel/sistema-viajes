using ErrorOr;
using MediatR;

namespace Application.Branches.Create;

public record CreateBranchCommand(
    string Name,
    string Address) : IRequest<ErrorOr<Unit>>;
