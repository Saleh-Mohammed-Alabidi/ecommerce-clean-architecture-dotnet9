namespace ecommerce.Domain.Common.Interface;

public interface IUtcTimeProvider
{
    DateTime Now { get; }
}