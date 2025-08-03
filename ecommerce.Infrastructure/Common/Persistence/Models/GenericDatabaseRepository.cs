// ecommerce.Infrastructure.Persistence

using ecommerce.Application.Common.Interfaces.Persistence;
using ecommerce.Domain.Common;
using ecommerce.Infrastructure.Common;
using Microsoft.EntityFrameworkCore;

namespace ecommerce.Infrastructure.Persistence;

public class GenericDatabaseRepository<TEntity, TKey>
    where TEntity : Entity<TKey>
{
    protected readonly EcommerceManagementDbContext _context;
    protected readonly DbSet<TEntity> _dbSet;

    public GenericDatabaseRepository(EcommerceManagementDbContext context)
    {
        _context = context;
        _dbSet = _context.Set<TEntity>();
    }

    public async Task<TEntity?> GetByIdAsync(TKey id, bool asNoTracking = true,
        CancellationToken cancellationToken = default)
    {
        IQueryable<TEntity> query = _dbSet;
        if (asNoTracking)
            query = query.AsNoTracking();

        return await query.FirstOrDefaultAsync(e => e.Id.Equals(id), cancellationToken);
    }

    public async Task<List<TEntity>> GetAllAsync(bool asNoTracking = true,
        CancellationToken cancellationToken = default)
    {
        IQueryable<TEntity> query = _dbSet;
        if (asNoTracking)
            query = query.AsNoTracking();

        return await query.ToListAsync(cancellationToken);
    }

    public async Task<TEntity> AddAsync(TEntity entity, CancellationToken cancellationToken = default)
    {
        await _dbSet.AddAsync(entity, cancellationToken);
        return entity;
    }

    public async Task<ICollection<TEntity>> AddRangeAsync(ICollection<TEntity> entities,
        CancellationToken cancellationToken = default)
    {
        await _dbSet.AddRangeAsync(entities, cancellationToken);
        return entities;
    }

    public void Update(TEntity entity)
    {
        _dbSet.Update(entity);
    }

    public void UpdateAll(List<TEntity> entities)
    {
        _dbSet.AttachRange(entities);
        foreach (var entity in entities)
        {
            Update(entity);
        }
    }

    public void Delete(TEntity entity)
    {
        _dbSet.Remove(entity);
    }


    public void DeleteRange(List<TEntity> entity, CancellationToken token = default)
    {
        _dbSet.RemoveRange(entity);
    }

    public IQueryable<TEntity> Queryable()
    {
        return _dbSet;
    }
}