using ecommerce.Application.Common.Interfaces.Persistence;
using ecommerce.Domain.Models.Customers;

namespace ecommerce.Infrastructure.Persistence;

public class CustomersRepository : ICustomersRepository
{
    private readonly GenericDatabaseRepository<Customers, int> genericDatabaseRepository;

    public CustomersRepository(GenericDatabaseRepository<Customers, int> genericDatabaseRepository)
    {
        this.genericDatabaseRepository = genericDatabaseRepository;
    }

    public async Task AddAsync(Customers data, CancellationToken token)
    {
        await genericDatabaseRepository.AddAsync(data, token);
    }

    public async Task AddRangeAsync(ICollection<Customers> data, CancellationToken token)
    {
        await genericDatabaseRepository.AddRangeAsync(data, token);
    }

    public async Task<Customers> GetByIdAsync(int id, CancellationToken token, bool asNoTracking = true)
    {
        return await genericDatabaseRepository.GetByIdAsync(id, asNoTracking, token);
    }

    public async Task<List<Customers>> GetAllAsync(CancellationToken token, bool asNoTracking = true)
    {
        return await genericDatabaseRepository.GetAllAsync(asNoTracking, token);
    }

    public void Delete(Customers data, CancellationToken token)
    {
        genericDatabaseRepository.Delete(data);
    }

    public void Update(Customers data, CancellationToken token)
    {
        genericDatabaseRepository.Update(data);
    }

    public void UpdateAll(List<Customers> data, CancellationToken token)
    {
        genericDatabaseRepository.UpdateAll(data);
    }
}