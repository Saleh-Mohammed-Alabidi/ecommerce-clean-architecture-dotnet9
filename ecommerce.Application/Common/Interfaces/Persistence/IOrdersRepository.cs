using ecommerce.Domain.Models.Orders;

namespace ecommerce.Application.Common.Interfaces.Persistence;

public interface IOrdersRepository
{
    Task AddAsync(Orders data, CancellationToken token);

    Task AddRangeAsync(ICollection<Orders> data, CancellationToken token);

    Task<Orders> GetByIdAsync(int id, CancellationToken token, bool asNoTracking);

    Task<List<Orders>> GetAllAsync(CancellationToken token, bool asNoTracking);

    void Delete(Orders data, CancellationToken token);

    void Update(Orders data, CancellationToken token);

    void UpdateAll(List<Orders> data, CancellationToken token);
}