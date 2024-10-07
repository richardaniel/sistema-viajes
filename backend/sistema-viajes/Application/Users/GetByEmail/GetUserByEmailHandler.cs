using Domain.Users;
using ErrorOr;
using MediatR;

namespace Application.Users.GetByEmail
{
    internal sealed class GetUserByEmailHandler : IRequestHandler<GetUserByEmail, ErrorOr<User>>
    {
        private readonly IUserRepository _userRepository;

        public GetUserByEmailHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<ErrorOr<User>> Handle(GetUserByEmail query, CancellationToken cancellationToken)
        {
            var user = await _userRepository.GetUserByEmail(query.Email);

            if (user is null)
            {
                return Error.NotFound("User.NotFound", $"User with email {query.Email} was not found.");
            }

            return user;
        }
    }
}
