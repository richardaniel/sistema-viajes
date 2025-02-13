using ErrorOr;
using MediatR;

namespace Application.Collaborators.Create;

public record CreateCollaboratorCommand(
    string Name,
    string LastName,
    string Email,
    string PhoneNumber):IRequest<ErrorOr<Unit>>;

