using ecommerce.Application.Common.Interfaces.Persistence;
using ecommerce.Domain.Models.Orders;

namespace ecommerce.Infrastructure.Persistence;

public class OrdersRepository : IOrdersRepository
{
    private readonly GenericDatabaseRepository<Orders, int> genericDatabaseRepository;

    public OrdersRepository(GenericDatabaseRepository<Orders, int> genericDatabaseRepository)
    {
        this.genericDatabaseRepository = genericDatabaseRepository;
    }

    public async Task AddAsync(Orders data, CancellationToken token)
    {
        await genericDatabaseRepository.AddAsync(data, token);
    }

    public async Task AddRangeAsync(ICollection<Orders> data, CancellationToken token)
    {
        await genericDatabaseRepository.AddRangeAsync(data, token);
    }

    public async Task<Orders> GetByIdAsync(int id, CancellationToken token, bool asNoTracking = true)
    {
        return await genericDatabaseRepository.GetByIdAsync(id, asNoTracking, token);
    }

    public async Task<List<Orders>> GetAllAsync(CancellationToken token, bool asNoTracking = true)
    {
        return await genericDatabaseRepository.GetAllAsync(asNoTracking, token);
    }

    public void Delete(Orders data, CancellationToken token)
    {
        genericDatabaseRepository.Delete(data);
    }

    public void Update(Orders data, CancellationToken token)
    {
        genericDatabaseRepository.Update(data);
    }

    public void UpdateAll(List<Orders> data, CancellationToken token)
    {
        genericDatabaseRepository.UpdateAll(data);
    }
}