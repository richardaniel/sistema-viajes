using MediatR;
using ErrorOr;
using Domain.Users;

namespace Application.Users.GetByEmail
{
    public record GetUserByEmail(string Email) : IRequest<ErrorOr<User>>;
}
