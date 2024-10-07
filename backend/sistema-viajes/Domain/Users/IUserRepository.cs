namespace Domain.Users;

public interface IUserRepository
{
    Task<User?> GetByIdAsync(UserId id);

    Task<User?> GetUserByEmail(string email);
    Task Add(User user);

     
        
}