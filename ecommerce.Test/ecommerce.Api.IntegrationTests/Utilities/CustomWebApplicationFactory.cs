using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.Extensions.Hosting;

namespace ecommerce.Api.IntegrationTests.Utilities;

public class CustomWebApplicationFactory : WebApplicationFactory<Program>
{
    protected override IHost CreateHost(IHostBuilder builder)
    {
        // Customize your test app environment if needed
        return base.CreateHost(builder);
    }
}