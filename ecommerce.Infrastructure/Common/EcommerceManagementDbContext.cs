using System.Reflection;
using ecommerce.Application.Common.Interfaces.Persistence;
using ecommerce.Domain.Models.Categories;
using ecommerce.Domain.Models.Customers;
using ecommerce.Domain.Models.OrderItems;
using ecommerce.Domain.Models.Orders;
using ecommerce.Domain.Models.Products;
using Microsoft.EntityFrameworkCore;

namespace ecommerce.Infrastructure.Common;

public class EcommerceManagementDbContext(DbContextOptions<EcommerceManagementDbContext> options)
    : DbContext(options), IUnitOfWork
{
    public virtual DbSet<Products> Products => Set<Products>();
    public virtual DbSet<Categories> Categories => Set<Categories>();

    public virtual DbSet<Customers> Customers => Set<Customers>();

    public virtual DbSet<Orders> Orders => Set<Orders>();

    public virtual DbSet<OrderItems> OrderItems => Set<OrderItems>();

    public async Task CommitChangesAsync(CancellationToken cancellationToken)
    {
        await SaveChangesAsync(cancellationToken);
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        base.OnModelCreating(modelBuilder);
    }
}