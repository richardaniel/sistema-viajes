using System.Threading.Tasks;
using Domain.Branches;
using Domain.CollaboratorBranches;
using Domain.Collaborators;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualBasic;

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
            .AnyAsync(cb => cb.CollaboratorId.Equals(customerId)  && cb.BranchId.Equals(branchId));
    }

    public async Task<List<Collaborator>> GetCustomersByBranchIdAsync(Guid branchId)
    {

        BranchId nuevaVariable = new BranchId(branchId);

        var customerIds = await _context.CollaboratorBranches
            .Where(cb => cb.BranchId == nuevaVariable)
            .Select(cb => cb.CollaboratorId)
            .ToListAsync();



    
        var collaborators = await _context.Customers
            .Where(c=>customerIds.Contains(c.CollaboratorId))
            .ToListAsync();

        return collaborators;
    }





}
