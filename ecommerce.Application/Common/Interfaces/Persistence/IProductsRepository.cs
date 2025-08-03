using ecommerce.Domain.Models.Products;

namespace ecommerce.Application.Common.Interfaces.Persistence;

public interface IProductsRepository
{
    Task AddAsync(Products data, CancellationToken token);

    Task AddRangeAsync(ICollection<Products> data, CancellationToken token);

    Task<Products> GetByIdAsync(int id, CancellationToken token);

    Task<List<Products>> GetAllAsync(CancellationToken token);

    void Delete(Products data, CancellationToken token);

    void Update(Products data, CancellationToken token);

    void UpdateAll(List<Products> data, CancellationToken token);
}