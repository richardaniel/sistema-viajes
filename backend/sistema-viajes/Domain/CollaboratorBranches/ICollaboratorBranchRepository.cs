using System.Threading.Tasks;
using Domain.Branches;
using Domain.Collaborators;

namespace Domain.CollaboratorBranches;

public interface ICollaboratorBranchRepository
{
    Task<CollaboratorBranch?> GetByIdAsync(CollaboratorBranchId id);
    Task Add(CollaboratorBranch collaboratorBranch);

    Task<bool> IsCustomerBranchAssociatedAsync(Guid customerId, Guid branchId);

    Task<List<Collaborator>> GetCustomersByBranchIdAsync(Guid branchId);
}
