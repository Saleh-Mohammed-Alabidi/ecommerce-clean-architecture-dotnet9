namespace ecommerce.Application.Common.Interfaces.Persistence;

public interface IProductsRepository
{
    Task<Domain.Models.Products.Products> AddAsync(Domain.Models.Products.Products data, CancellationToken token);

    Task<ICollection<Domain.Models.Products.Products>> AddRangeAsync(ICollection<Domain.Models.Products.Products> data, CancellationToken token);

    Task<Domain.Models.Products.Products?> GetByIdAsync(int id, CancellationToken token, bool asNoTracking=true);

    Task<List<Domain.Models.Products.Products>> GetAllAsync(CancellationToken token, bool asNoTracking=true);

    void Delete(Domain.Models.Products.Products data, CancellationToken token);

    void Update(Domain.Models.Products.Products data, CancellationToken token);

    void UpdateAll(List<Domain.Models.Products.Products> data, CancellationToken token);
}