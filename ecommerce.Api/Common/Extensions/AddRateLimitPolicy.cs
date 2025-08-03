using System.Threading.RateLimiting;
using ecommerce.Common.Configuration.Constrain;
using Microsoft.Extensions.Options;

namespace ecommerce.Common.Extensions;

public static class RateLimitPolicyExtensions
{
    public static IServiceCollection AddRateLimitPolicy(this IServiceCollection services,
        IOptions<RateLimitConstrain> rateLimitConfig)
    {
        services.AddRateLimiter(options =>
        {
            options.AddPolicy("GlobalPolicy", httpContext =>
            {
                var ipAddress = httpContext.Connection.RemoteIpAddress?.ToString() ?? "unknown";

                return RateLimitPartition.GetFixedWindowLimiter(ipAddress, _ => new FixedWindowRateLimiterOptions
                {
                    PermitLimit = rateLimitConfig.Value.PermitLimit,
                    Window = TimeSpan.FromMinutes(rateLimitConfig.Value.TimeSpan),
                    QueueLimit = rateLimitConfig.Value.QueueLimit,
                    QueueProcessingOrder = QueueProcessingOrder.OldestFirst
                });
            });
        });

        return services;
    }
}