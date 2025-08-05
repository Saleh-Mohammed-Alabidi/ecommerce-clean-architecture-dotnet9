using ecommerce.Application.Common.Interfaces.Persistence;
using ecommerce.Domain.Models.Categories;

namespace ecommerce.Infrastructure.Persistence;

public class CategoriesRepository : ICategoriesRepository
{
    private readonly GenericDatabaseRepository<Categories, int> genericDatabaseRepository;

    public CategoriesRepository(GenericDatabaseRepository<Categories, int> genericDatabaseRepository)
    {
        this.genericDatabaseRepository = genericDatabaseRepository;
    }

    public async Task AddAsync(Categories data, CancellationToken token)
    {
        await genericDatabaseRepository.AddAsync(data, token);
    }

    public async Task AddRangeAsync(ICollection<Categories> data, CancellationToken token)
    {
        await genericDatabaseRepository.AddRangeAsync(data, token);
    }

    public async Task<Categories> GetByIdAsync(int id, CancellationToken token, bool asNoTracking = true)
    {
        return await genericDatabaseRepository.GetByIdAsync(id, asNoTracking, token);
    }

    public async Task<List<Categories>> GetAllAsync(CancellationToken token, bool asNoTracking = true)
    {
        return await genericDatabaseRepository.GetAllAsync(asNoTracking, token);
    }

    public void Delete(Categories data, CancellationToken token)
    {
        genericDatabaseRepository.Delete(data);
    }

    public void Update(Categories data, CancellationToken token)
    {
        genericDatabaseRepository.Update(data);
    }

    public void UpdateAll(List<Categories> data, CancellationToken token)
    {
        genericDatabaseRepository.UpdateAll(data);
    }
}