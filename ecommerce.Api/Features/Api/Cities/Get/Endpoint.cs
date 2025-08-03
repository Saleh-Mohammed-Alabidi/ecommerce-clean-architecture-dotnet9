using ecommerce.Common.Api;
using EloroShop.Api.Common.Filters;

namespace ecommerce.Api.Features.Cities.Get;

public class Endpoint : BaseApi
{
    public override void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapGet(Router.Cities.Get, () => "Cities")
            .RequireRateLimiting("GlobalPolicy").AddEndpointFilter<LoggingFilter>();
    }
}