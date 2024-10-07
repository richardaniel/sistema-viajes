using System.Threading.Tasks;
using Domain.Branches;
using Domain.Customers;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Persistence.Repositories;

public class BranchRepository : IBranchRepository
{
    private readonly ApplicationDbContext _context;

    public BranchRepository(ApplicationDbContext context)
    {
        _context = context ?? throw new ArgumentNullException(nameof(context));
    }

    public async Task Add(Branch branch) => await _context.Branches.AddAsync(branch);

    public async Task<List<Branch?>> GetAllAsync()
    {
          return await _context.Branches.ToListAsync();
    }

    public async Task<Branch?> GetByIdAsync(BranchId id) => 
        await _context.Branches.SingleOrDefaultAsync(b => b.Id==id);

    public Task Update(Branch branch)
    {
        throw new NotImplementedException();
    }


    public async Task<List<Customer>> GetCustomersByBranchIdAsync(Guid branchId)
{
    return await _context.CollaboratorBranches
        .Where(cb => cb.BranchId.Value == branchId) // Filtrar por BranchId
        .Select(cb => cb.CustomerId) // Obtener solo el CustomerId
        .Join(_context.Customers, // Hacer join con la tabla Customers
              customerId => customerId,
              customer => customer.CustomerId,
              (customerId, customer) => customer) // Proyectar el Customer
        .ToListAsync();
}


}
