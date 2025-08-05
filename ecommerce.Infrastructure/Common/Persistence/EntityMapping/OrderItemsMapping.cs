using ecommerce.Domain.Models.OrderItems;
using ecommerce.Domain.Models.Orders;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ecommerce.Infrastructure.Common.Persistence.EntityMapping;

public class OrderItemsMapping : IEntityTypeConfiguration<OrderItems>
{
    public void Configure(EntityTypeBuilder<OrderItems> builder)
    {
        builder.HasKey(oi => oi.Id); // You may want to add Id to OrderItems if not already present

        builder.Property(oi => oi.ProductId)
            .IsRequired();

        builder.Property(oi => oi.UnitPrice)
            .IsRequired()
            .HasPrecision(10, 2);

        builder.Property(oi => oi.Quantity)
            .IsRequired();

        builder.Property(o => o.CreatedAt)
            .IsRequired()
            .HasColumnType("datetime");

        builder.Property(o => o.UpdateAt)
            .IsRequired()
            .HasColumnType("datetime");

        builder.Property(e => e.OrderId).HasColumnType("int(11)");


        // Configure FK to Orders table, if not done via shadow property in OrderMapping
        builder.HasOne(oi => oi.Order)
            .WithMany(o => o.Items)
            .HasForeignKey(oi => oi.OrderId)
            .OnDelete(DeleteBehavior.Cascade);
        
    }
}