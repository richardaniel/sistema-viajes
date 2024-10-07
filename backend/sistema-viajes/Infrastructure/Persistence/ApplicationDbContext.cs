using Apllication.Data;
using Domain.Branches;
using Domain.CollaboratorBranches;
using Domain.Customers;
using Domain.Primitives;
using Domain.Transporters;
using Domain.TripCollaborators;
using Domain.Trips;
using Domain.Users;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Persistence;

public class ApplicationDbContext : DbContext ,IApplicationDbContext ,IUnitOfWork{
    
    public readonly IPublisher _publisher;

    public ApplicationDbContext(DbContextOptions options ,IPublisher publisher):base(options)
    {
        _publisher = publisher ?? throw new ArgumentNullException(nameof(publisher));
    }

    public DbSet<Customer> Customers {get;set;}
    public DbSet<User> Users {get;set;}

    public DbSet<Trip> Trips {get;set;}

    public DbSet<Transporter> Transporters {get;set;}

    public DbSet<Branch> Branches {get;set;}

    public DbSet<CollaboratorBranch> CollaboratorBranches {get;set;}

    public DbSet<TripCollaborator> TripCollaborators {get;set;}

    //Aplicamos configurados customizados , para que no haga un automapeo 
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
       modelBuilder.ApplyConfigurationsFromAssembly(typeof(ApplicationDbContext).Assembly);
    }

    public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken=new CancellationToken()){
        var domainEvents = ChangeTracker.Entries<AggregateRoot>()
        .Select(e=>e.Entity)
        .Where(e => e.GetDomainEvents().Any())
        .SelectMany(e=>e.GetDomainEvents());

        var result = await base.SaveChangesAsync(cancellationToken);

        foreach(var domainEvent in domainEvents){
            await _publisher.Publish(domainEvent,cancellationToken);
        }

      return result;  
    }
    
}