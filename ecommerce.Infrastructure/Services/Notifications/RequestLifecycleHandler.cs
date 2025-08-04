using ecommerce.Application.Common.Notifications;
using MediatR;
using Serilog;

namespace ecommerce.Infrastructure.Services.Notifications;

public class RequestLifecycleHandler : INotificationHandler<RequestLifecycleNotification>
{
    public Task Handle(RequestLifecycleNotification notification, CancellationToken cancellationToken)
    {
        // Use message template placeholders { } for structured logging
        Log.Information("Request {Method} {Path} lifecycle stage: {Stage}",
            notification.Method,
            notification.Path,
            notification.Stage);

        return Task.CompletedTask;
    }
}