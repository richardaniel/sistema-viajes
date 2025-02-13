namespace Infrastructure.Persistence.Repositories;

using System.Collections.Generic;
using System.Threading.Tasks;
using Domain.Collaborators;
using Microsoft.EntityFrameworkCore;

public class CustomerRepository : ICollaboratorRepository
{

    private readonly ApplicationDbContext _context;

    public CustomerRepository(ApplicationDbContext context)
    {
        _context = context ?? throw new ArgumentNullException(nameof(context));
    }

    public async Task Add(Collaborator customer)=> await _context.Customers.AddAsync(customer);

    public async Task<List<Collaborator>> GetAllAsync()
    {
        return await _context.Customers.ToListAsync();
    }

    public async Task<Collaborator?> GetByIdAsync(CollaboratorId id)=> await _context.Customers.SingleOrDefaultAsync(c=>c.CollaboratorId==id);

    
}

