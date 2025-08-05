namespace ecommerce.Application.Common.Interfaces.Persistence;

public interface IUnitOfWork
{
    Task CommitChangesAsync(CancellationToken cancellationToken);
}