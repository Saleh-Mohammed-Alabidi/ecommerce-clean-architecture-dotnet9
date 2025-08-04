using ecommerce.Application.Common.Notifications;
using MediatR;

namespace ecommerce.Common.Middleware;

public class CustomMiddleware
{
    private readonly RequestDelegate _next;
    private readonly IMediator _mediator;

    public CustomMiddleware(RequestDelegate next, IMediator mediator)
    {
        _next = next;
        _mediator = mediator;
    }

    public async Task InvokeAsync(HttpContext context)
    {
        try
        {
            await _mediator.Publish(new RequestLifecycleNotification(
                Path: context.Request.Path,
                Method: context.Request.Method,
                Stage: Lifecycle.Begin));

            await _next(context);

            await _mediator.Publish(new RequestLifecycleNotification(
                Path: context.Request.Path,
                Method: context.Request.Method,
                Stage: Lifecycle.Finish));
        }
        catch (Exception ex)
        {
            var errorDetails = new ErrorDetails(
                Message: ex.Message,
                StackTrace: ex.StackTrace,
                ExceptionType: ex.GetType().FullName ?? "UnknownException"
            );

            await _mediator.Publish(new ErrorNotification(errorDetails));

            context.Response.StatusCode = 500;
            await context.Response.WriteAsync("Error occurred");
        }
    }
}