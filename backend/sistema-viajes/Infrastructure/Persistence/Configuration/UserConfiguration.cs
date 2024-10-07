using Domain.Users;
using Domain.ValueObjects;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Persistence.Configuration;

public class UserConfiguration : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        
        builder.HasKey(c => c.Id);

        builder.Property(c=>c.Id).HasConversion(
            userId=>userId.Value,
            value=>new UserId(value)
        );

        builder.Property(c => c.Name).HasMaxLength(50);
        builder.Property(c=>c.Email).HasMaxLength(50);
        builder.Property(c => c.Password);
        builder.HasIndex(c=>c.Email).IsUnique();

         builder.Property(c=>c.Rol).HasConversion(
            rol=>rol.Value,
            value=>Rol.Create(value)!
        );
        
        builder.Property(c=>c.Active);

    }
}