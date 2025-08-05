using ecommerce.Domain.Models.Categories;

namespace ecommerce.Application.Common.Interfaces.Persistence;

public interface ICategoriesRepository
{
    Task AddAsync(Categories data, CancellationToken token);

    Task AddRangeAsync(ICollection<Categories> data, CancellationToken token);

    Task<Categories> GetByIdAsync(int id, CancellationToken token, bool asNoTracking);

    Task<List<Categories>> GetAllAsync(CancellationToken token, bool asNoTracking);

    void Delete(Categories data, CancellationToken token);

    void Update(Categories data, CancellationToken token);

    void UpdateAll(List<Categories> data, CancellationToken token);
}