using ecommerce.Application.Common.Interfaces.Persistence;
using ecommerce.Domain.Models.Products;

namespace ecommerce.Infrastructure.Persistence;

public class ProductsRepository:IProductsRepository
{
    
    public Task AddAsync(Products data, CancellationToken token)
    {
        throw new NotImplementedException();
    }

    public Task AddRangeAsync(ICollection<Products> data, CancellationToken token)
    {
        throw new NotImplementedException();
    }

    public Task<Products> GetByIdAsync(int id, CancellationToken token)
    {
        throw new NotImplementedException();
    }

    public Task<List<Products>> GetAllAsync(CancellationToken token)
    {
        throw new NotImplementedException();
    }

    public void Delete(Products data, CancellationToken token)
    {
        throw new NotImplementedException();
    }

    public void Update(Products data, CancellationToken token)
    {
        throw new NotImplementedException();
    }

    public void UpdateAll(List<Products> data, CancellationToken token)
    {
        throw new NotImplementedException();
    }
}