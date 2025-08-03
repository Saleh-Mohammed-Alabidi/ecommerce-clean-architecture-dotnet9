using Scalar.AspNetCore;

namespace ecommerce.Common.Extensions;

public static class ScalarApiExtensions
{
    public static WebApplication UseScalarApi(this WebApplication app)
    {
        app.MapScalarApiReference(options =>
        {
            options
                .WithTitle("eCommerce API")
                .WithHttpBearerAuthentication(bearer =>
                {
                    bearer.Token = "your-test-token"; // For testing only; avoid in production
                })
                .WithPersistentAuthentication();
        });
        return app;
    }
}