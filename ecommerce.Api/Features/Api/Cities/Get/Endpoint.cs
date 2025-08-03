using ecommerce.Common.Api;

namespace ecommerce.Api.Features.Cities.Get;

public class Endpoint : BaseApi
{
    public override void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapGet(Router.Cities.Get, () => "Cities").RequireRateLimiting("GlobalPolicy");
    }
}