namespace Infrastructure.Persistence.Repositories;

using System.Threading.Tasks;
using Domain.Users;
using Microsoft.EntityFrameworkCore;

public class UserRepository : IUserRepository
{
    private readonly ApplicationDbContext _context;

    public UserRepository(ApplicationDbContext context)
    {
        _context = context ?? throw new ArgumentNullException(nameof(context));
    }

    public async Task Add(User user)=> await _context.Users.AddAsync(user);
    public async Task<User?> GetByIdAsync(UserId id)=> await _context.Users.SingleOrDefaultAsync(c=>c.Id==id);
    public async Task<User?> GetUserByEmail(String email)=> await _context.Users.SingleOrDefaultAsync(c=>c.Email==email);

    
}