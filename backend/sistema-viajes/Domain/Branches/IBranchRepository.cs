namespace Domain.Branches;

public interface IBranchRepository
{
    Task<Branch?> GetByIdAsync(BranchId id);

    Task<List<Branch?>> GetAllAsync();
    Task Add(Branch branch);
    Task Update(Branch branch);

   
}
