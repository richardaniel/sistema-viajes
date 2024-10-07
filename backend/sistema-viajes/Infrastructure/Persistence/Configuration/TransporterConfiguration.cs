using Domain.Transporters;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Persistence.Configuration;

public class TransporterConfiguration : IEntityTypeConfiguration<Transporter>
{
    public void Configure(EntityTypeBuilder<Transporter> builder)
    {
        builder.HasKey(t => t.Id);

        builder.Property(t => t.Id).HasConversion(
            transporterId => transporterId.Value,
            value => new TransporterId(value)
        );
        
        builder.Property(t => t.Name).HasMaxLength(100);
       builder.Property(t => t.RatePerKm)
         .HasColumnType("decimal(18, 2)"); // Ajusta la precisión y escala según tus necesidades
       
    }
}
