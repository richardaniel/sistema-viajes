namespace Domain.Primitives;

public interface IUnitOfWork{
    public Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }
}