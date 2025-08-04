using MediatR;

namespace ecommerce.Application.Common.Notifications;


public record ErrorDetails(string Message, string? StackTrace, string ExceptionType);

public record ErrorNotification(ErrorDetails Details) : INotification;
