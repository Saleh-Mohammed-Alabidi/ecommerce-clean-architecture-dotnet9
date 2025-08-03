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
                // Use the remote IP address as the partition key for rate limiting
                var ipAddress = httpContext.Connection.RemoteIpAddress?.ToString() ?? "unknown";

                return RateLimitPartition.GetFixedWindowLimiter(ipAddress, _ => new FixedWindowRateLimiterOptions
                {
                    PermitLimit = rateLimitConfig.Value.PermitLimit, // Allow X requests
                    Window = TimeSpan.FromMinutes(rateLimitConfig.Value.TimeSpan), // Reset every X Minutes
                    QueueLimit = rateLimitConfig.Value.QueueLimit, // Queue X Queue extra requests
                    QueueProcessingOrder = QueueProcessingOrder.OldestFirst
                });
            });
        });
        return services;
    }
}