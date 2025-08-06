using ecommerce.Application.Common.Interfaces.Persistence;
using ecommerce.Domain.Models.Products;

namespace ecommerce.Infrastructure.Persistence;

public class ProductsRepository : IProductsRepository
{
    private readonly GenericDatabaseRepository<Products, int> genericDatabaseRepository;

    public ProductsRepository(GenericDatabaseRepository<Products, int> genericDatabaseRepository)
    {
        this.genericDatabaseRepository = genericDatabaseRepository;
    }

    public async Task<Products> AddAsync(Products data, CancellationToken token)
    {
       return await genericDatabaseRepository.AddAsync(data, token);
    }

    public async Task<ICollection<Products>> AddRangeAsync(ICollection<Products> data, CancellationToken token)
    {
       return await genericDatabaseRepository.AddRangeAsync(data, token);
    }

    public async Task<Products?> GetByIdAsync(int id, CancellationToken token, bool asNoTracking = true)
    {
        return await genericDatabaseRepository.GetByIdAsync(id, asNoTracking, token);
    }

    public async Task<List<Products>> GetAllAsync(CancellationToken token, bool asNoTracking = true)
    {
        return await genericDatabaseRepository.GetAllAsync(asNoTracking, token);
    }

    public void Delete(Products data, CancellationToken token)
    {
        genericDatabaseRepository.Delete(data);
    }

    public void Update(Products data, CancellationToken token)
    {
        genericDatabaseRepository.Update(data);
    }

    public void UpdateAll(List<Products> data, CancellationToken token)
    {
        genericDatabaseRepository.UpdateAll(data);
    }
}