using System.Reflection;
using ecommerce.Application.Common.Interfaces.Persistence;
using ecommerce.Domain.Models.Products;
using Microsoft.EntityFrameworkCore;

namespace ecommerce.Infrastructure.Common;

public class EcommerceManagementDbContext(DbContextOptions<EcommerceManagementDbContext> options)
    : DbContext(options), IUnitOfWork
{
    public virtual DbSet<Products> Products => Set<Products>();

    public async Task CommitChangesAsync()
    {
        await SaveChangesAsync();
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        base.OnModelCreating(modelBuilder);
    }
}