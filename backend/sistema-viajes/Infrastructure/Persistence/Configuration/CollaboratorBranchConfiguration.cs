using Domain.Branches;
using Domain.CollaboratorBranches;
using Domain.Customers;
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

        builder.Property(cb => cb.CustomerId).HasConversion(
              customerId=>customerId.Value,
            value=>new CustomerId(value)
        ).IsRequired();

        builder.Property(cb => cb.BranchId).HasConversion(
                branchId => branchId.Value,
                value => new BranchId(value) // Asegúrate de que este tipo sea correcto
            ).IsRequired();
        builder.Property(cb => cb.DistanceKm)
            .HasDefaultValue(0) // Valor por defecto
            .IsRequired(); // Asegúrate de que este campo sea requerido

        builder.HasIndex(cb => new { cb.CustomerId, cb.BranchId }).IsUnique(); // Asegura la unicidad

        builder.HasOne<Customer>() // Define la relación con la entidad Collaborator
            .WithMany() // Si es una relación uno a muchos
            .HasForeignKey(cb => cb.CustomerId)
            .OnDelete(DeleteBehavior.Cascade); // Configura el comportamiento de eliminación

        builder.HasOne<Branch>() // Define la relación con la entidad Branch
            .WithMany() // Si es una relación uno a muchos
            .HasForeignKey(cb => cb.BranchId)
            .OnDelete(DeleteBehavior.Cascade); // Configura el comportamiento de eliminación
    }
}
