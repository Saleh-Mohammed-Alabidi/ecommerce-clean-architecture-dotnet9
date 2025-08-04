using MediatR;

namespace ecommerce.Application.Common.Notifications;

public enum Lifecycle
{
    Begin,
    Finish
}

public record RequestLifecycleNotification(
    string Path,
    string Method,
    Lifecycle Stage
) : INotification;