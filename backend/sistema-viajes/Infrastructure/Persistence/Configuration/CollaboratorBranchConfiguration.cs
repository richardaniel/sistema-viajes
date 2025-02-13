using Domain.Branches;
using Domain.CollaboratorBranches;
using Domain.Collaborators;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Persistence.Configuration;

public class CollaboratorBranchConfiguration : IEntityTypeConfiguration<CollaboratorBranch>
{
    public void Configure(EntityTypeBuilder<CollaboratorBranch> builder)
    {
        builder.HasKey(cb => cb.Id);

        builder.Property(cb => cb.Id).HasConversion(
            collaboratorBranchId => collaboratorBranchId.Value,
            value => new CollaboratorBranchId(value)
        );

        builder.Property(cb => cb.CollaboratorId).HasConversion(
              collaboratorId=>collaboratorId.Value,
            value=>new CollaboratorId(value)
        ).IsRequired();

        builder.Property(cb => cb.BranchId).HasConversion(
                branchId => branchId.Value,
                value => new BranchId(value) 
            ).IsRequired();
        builder.Property(cb => cb.DistanceKm)
            .HasDefaultValue(0) 
            .IsRequired();

        builder.HasIndex(cb => new { cb.CollaboratorId, cb.BranchId }).IsUnique(); 

        builder.HasOne<Collaborator>() 
            .WithMany() 
            .HasForeignKey(cb => cb.CollaboratorId)
            .OnDelete(DeleteBehavior.Cascade); 

        builder.HasOne<Branch>() 
            .WithMany() 
            .HasForeignKey(cb => cb.BranchId)
            .OnDelete(DeleteBehavior.Cascade); 
    }
}
