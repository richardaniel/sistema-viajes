using ErrorOr;
using MediatR;

namespace Application.Users.Create;

public record CreateUserCommand(
    string Name,
    string Email,
    string Password,
    string Rol):IRequest<ErrorOr<Unit>>;



  