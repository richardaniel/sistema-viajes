using Domain.Collaborators;
using Microsoft.EntityFrameworkCore;

namespace Apllication.Data;

public interface IApplicationDbContext{

    DbSet<Collaborator> Customers{get;set;}
    

    Task<int>SaveChangesAsync(CancellationToken cancellationToken = default );
}