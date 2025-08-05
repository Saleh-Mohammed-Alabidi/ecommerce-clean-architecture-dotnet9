using ecommerce.Domain.Models.Customers;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ecommerce.Infrastructure.Common.Persistence.EntityMapping;

public class CustomerMapping : IEntityTypeConfiguration<Customers>
{
    public void Configure(EntityTypeBuilder<Customers> builder)
    {
        builder.HasKey(c => c.Id).HasName("PRIMARY");

        builder.Property(c => c.Id)
            .ValueGeneratedOnAdd();

        builder.Property(c => c.FullName)
            .IsRequired()
            .HasMaxLength(200);

        builder.Property(c => c.Email)
            .IsRequired()
            .HasMaxLength(255);

        builder.Property(e => e.CreatedAt).HasColumnType("datetime");

        builder.Property(e => e.UpdateAt).HasColumnType("datetime");
    }
}