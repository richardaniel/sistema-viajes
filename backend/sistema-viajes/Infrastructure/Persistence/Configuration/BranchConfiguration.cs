using Domain.Branches;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Persistence.Configuration;

public class BranchConfiguration : IEntityTypeConfiguration<Branch>
{
    public void Configure(EntityTypeBuilder<Branch> builder)
    {
        builder.HasKey(b => b.Id);

        builder.Property(b => b.Id).HasConversion(
            branchId => branchId.Value,
            value => new BranchId(value)
        );

        builder.Property(b => b.Name).HasMaxLength(100);
        builder.Property(b => b.Address).HasMaxLength(255);
 
    }
}
