using ecommerce.Domain.Models.Customers;

namespace ecommerce.Application.Common.Interfaces.Persistence;

public interface ICustomersRepository
{
    Task AddAsync(Customers data, CancellationToken token);

    Task AddRangeAsync(ICollection<Customers> data, CancellationToken token);

    Task<Customers> GetByIdAsync(int id, CancellationToken token, bool asNoTracking);

    Task<List<Customers>> GetAllAsync(CancellationToken token, bool asNoTracking);

    void Delete(Customers data, CancellationToken token);

    void Update(Customers data, CancellationToken token);

    void UpdateAll(List<Customers> data, CancellationToken token);
}