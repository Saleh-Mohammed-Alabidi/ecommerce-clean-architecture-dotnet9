using ecommerce.Domain.Models.Orders;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ecommerce.Infrastructure.Common.Persistence.EntityMapping;

public class OrderMapping : IEntityTypeConfiguration<Orders>
{
    public void Configure(EntityTypeBuilder<Orders> builder)
    {
        builder.HasKey(o => o.Id);

        builder.Property(o => o.Id)
            .ValueGeneratedOnAdd();

        builder.Property(o => o.CustomerId)
            .IsRequired();

        builder.Property(o => o.CreatedAt)
            .IsRequired()
            .HasColumnType("datetime");

        builder.Property(o => o.UpdateAt)
            .IsRequired()
            .HasColumnType("datetime");


        // Relationship: Order belongs to one Customer
        builder.HasOne(o => o.Customer)
            .WithMany(o =>
                o.Orders) // Assuming Customer does not have navigation collection for orders; otherwise put that collection property here
            .HasForeignKey(o => o.CustomerId)
            .OnDelete(DeleteBehavior.Restrict);

        // Relationship: Order has many OrderItems
        builder.HasMany(o => o.Items)
            .WithOne(oi => oi.Order) // ✅ specify navigation
            .HasForeignKey(oi => oi.OrderId) // ✅ real FK
            .OnDelete(DeleteBehavior.Cascade);
    }
}