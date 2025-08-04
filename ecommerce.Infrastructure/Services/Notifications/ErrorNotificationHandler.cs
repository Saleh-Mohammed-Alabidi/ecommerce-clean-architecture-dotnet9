using ecommerce.Application.Common.Notifications;
using MediatR;
using Serilog;

namespace ecommerce.Infrastructure.Services.Notifications;

public class ErrorNotificationHandler : INotificationHandler<ErrorNotification>
{
    public Task Handle(ErrorNotification notification, CancellationToken cancellationToken)
    {
        // Log error (replace with Serilog or external logger if needed)
        var details = notification.Details;
        Log.Error("[{ExceptionType}] {Message} - StackTrace: {StackTrace}",
            details.ExceptionType,
            details.Message,
            details.StackTrace);
        // You could also send to Sentry, Email, etc.

        return Task.CompletedTask;
    }
}