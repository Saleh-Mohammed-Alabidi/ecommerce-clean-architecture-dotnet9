using ecommerce.Domain.Models.Products;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ecommerce.Infrastructure.Common.Persistence.EntityMapping;

public class ProductsMapping : IEntityTypeConfiguration<Products>
{
    public void Configure(EntityTypeBuilder<Products> builder)
    {
        builder.Property(app => app.Id)
            .ValueGeneratedOnAdd();

        builder.HasKey(e => e.Id).HasName("PRIMARY");

        builder.Property(e => e.Name).HasMaxLength(100);

        builder.Property(e => e.Price).HasPrecision(10, 2);

        builder.Property(e => e.CreatedAt).HasColumnType("datetime");

        builder.Property(e => e.UpdateAt).HasColumnType("datetime");
        
        builder.Property(e => e.CategoryId).HasColumnType("int(11)");

        builder.HasOne(e => e.Category)
            .WithMany(c => c.Products)
            .HasForeignKey(e => e.CategoryId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}