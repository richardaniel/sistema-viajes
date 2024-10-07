using System.Threading.Tasks;
using Domain.CollaboratorBranches;
using Domain.Customers;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Persistence.Repositories;

public class CollaboratorBranchRepository : ICollaboratorBranchRepository
{
    private readonly ApplicationDbContext _context;

    public CollaboratorBranchRepository(ApplicationDbContext context)
    {
        _context = context ?? throw new ArgumentNullException(nameof(context));
    }

    public async Task Add(CollaboratorBranch collaboratorBranch)
    {
        await _context.CollaboratorBranches.AddAsync(collaboratorBranch);
    }

    public async Task<CollaboratorBranch?> GetByIdAsync(CollaboratorBranchId id)
    {
        return await _context.CollaboratorBranches
            .SingleOrDefaultAsync(cb => cb.Id == id);
    }


     public async Task<bool> IsCustomerBranchAssociatedAsync(Guid customerId, Guid branchId)
    {
        return await _context.CollaboratorBranches
            .AnyAsync(cb => cb.CustomerId.Equals(customerId)  && cb.BranchId.Equals(branchId));
    }
    
    public async Task<List<Customer>> GetCustomersByBranchIdAsync(Guid branchId)
{
    return await _context.CollaboratorBranches
        .Where(cb => cb.BranchId.Value == branchId) // Filtrar por BranchId
        .Select(cb => cb.CustomerId) // Obtener solo el CustomerId
        .Join(_context.Customers, // Hacer join con la tabla Customers
              customerId => customerId,
              customer => customer.CustomerId,
              (customerId, customer) => customer)// Proyectar el Customer
        .ToListAsync();
}

    
}
