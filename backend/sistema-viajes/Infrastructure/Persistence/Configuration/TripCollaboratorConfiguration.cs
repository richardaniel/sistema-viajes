using Domain.Customers;
using Domain.TripCollaborators;
using Domain.Trips;
using Domain.Users;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Persistence.Configuration;

public class TripCollaboratorConfiguration : IEntityTypeConfiguration<TripCollaborator>
{
    public void Configure(EntityTypeBuilder<TripCollaborator> builder)
    {
        builder.HasKey(tc => tc.Id);

        builder.Property(tc => tc.Id).HasConversion(
            tripCollaboratorId => tripCollaboratorId.Value,
            value => new TripCollaboratorId(value)
        );

        builder.Property(tc => tc.TripId).IsRequired();
        builder.Property(tc => tc.CustomerId).HasConversion(
             customerId=>customerId.Value,
            value=>new CustomerId(value)
        ).IsRequired();
        builder.Property(tc => tc.DistanceKm)
            .HasColumnType("decimal(5, 2)") // Especifica el tipo de columna
            .HasPrecision(5, 2)
            .IsRequired(); // Asegúrate de que este campo sea requerido

        builder.Property(tc => tc.Cost)
            .HasColumnType("decimal(10, 2)") // Especifica el tipo de columna
            .HasPrecision(10, 2)
            .IsRequired(); // Asegúrate de que este campo sea requerido

        builder.HasIndex(tc => new { tc.TripId, tc.CustomerId }).IsUnique(); // Asegura la unicidad

        builder.HasOne<Trip>() // Define la relación con la entidad Trip
            .WithMany() // Si es una relación uno a muchos
            .HasForeignKey(tc => tc.TripId)
            .OnDelete(DeleteBehavior.Cascade); // Configura el comportamiento de eliminación

        builder.HasOne<Customer>() // Define la relación con la entidad Collaborator
            .WithMany() // Si es una relación uno a muchos
            .HasForeignKey(tc => tc.CustomerId)
            .OnDelete(DeleteBehavior.Cascade); // Configura el comportamiento de eliminación
    }
}
