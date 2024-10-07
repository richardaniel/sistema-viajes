using Domain.Branches;
using Domain.Transporters;
using Domain.Trips;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Persistence.Configuration;

public class TripConfiguration : IEntityTypeConfiguration<Trip>
{
    public void Configure(EntityTypeBuilder<Trip> builder)
    {
        builder.HasKey(t => t.Id);

        builder.Property(t => t.Id).HasConversion(
            tripId => tripId.Value,
            value => new TripId(value)
        );

        builder.Property(t => t.TripDate);

        builder.Property(t => t.TotalDistance)
            .HasColumnType("decimal(5, 2)")
            .IsRequired();

        builder.Property(t => t.TotalCost)
            .HasColumnType("decimal(10, 2)")
            .IsRequired();

        builder.HasOne<Branch>()
            .WithMany()
            .HasForeignKey(t => t.BranchId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne<Transporter>()
            .WithMany()
            .HasForeignKey(t => t.TransporterId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasMany(t => t.Customers)
            .WithOne()
            .HasForeignKey("TripId");
    }
}
