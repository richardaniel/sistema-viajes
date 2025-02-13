using Domain.Collaborators;
using Domain.ValueObjects;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Persistence.Configuration;

public class CollaboratorConfiguration : IEntityTypeConfiguration<Collaborator>
{
    public void Configure(EntityTypeBuilder<Collaborator> builder)
    {
        
        builder.HasKey(c => c.CollaboratorId);

        builder.Property(c=>c.CollaboratorId).HasConversion(
            customerId=>customerId.Value,
            value=>new CollaboratorId(value)
        );

        builder.Property(c => c.Name).HasMaxLength(50);
        builder.Property(c=>c.LastName).HasMaxLength(50);
        builder.Ignore(c => c.FullName);
        builder.Property(c=>c.Email).HasMaxLength(255);
        builder.HasIndex(c=>c.Email).IsUnique();

         builder.Property(c=>c.PhoneNumber).HasConversion(
            phoneNumber=>phoneNumber.Value,
            value=>PhoneNumber.Create(value)!
        ).HasMaxLength(9);
        
        builder.Property(c=>c.Active);

    }
}