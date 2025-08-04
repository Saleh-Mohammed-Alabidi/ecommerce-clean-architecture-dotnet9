using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Extensions;
using Serilog;

namespace EloroShop.Api.Common.Filters;

public class LoggingFilter : IEndpointFilter
{
    public async ValueTask<object?> InvokeAsync(EndpointFilterInvocationContext context, EndpointFilterDelegate next)
    {
        var httpContext = context.HttpContext;
        var request = httpContext.Request;

        Log.Information("Request Start: {Method} {Url}", request.Method, request.GetDisplayUrl());

        var result = await next(context);

        Log.Information("Request Completed: {Method} {Url} => {@Result}", request.Method, request.GetDisplayUrl(),
            result);

        return result;
    }
}