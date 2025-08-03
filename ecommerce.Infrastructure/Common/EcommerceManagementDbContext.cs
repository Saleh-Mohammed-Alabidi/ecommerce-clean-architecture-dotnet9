using System.Reflection;
using ecommerce.Application.Common.Interfaces.Persistence;
using Microsoft.EntityFrameworkCore;

namespace ecommerce.Infrastructure.Common;

public class EcommerceManagementDbContext(DbContextOptions<EcommerceManagementDbContext> options)
    : DbContext(options), IUnitOfWork
{
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