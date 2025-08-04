using ecommerce.Common.Api;
using ecommerce.Common.Behaviors;
using ecommerce.Common.Extensions;
using EloroShop.Api.Common.Filters;

namespace ecommerce.Api.Features.Cities.Get;

public class Endpoint : BaseApi
{
    public override void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapGet(Router.Cities.Get, ([AsParameters] Request request) =>
            {
                return Results.Ok(request.Id);
            })
            .RequireRateLimiting("GlobalPolicy")
            .AddEndpointFilter<LoggingFilter>()
            .WithValidation<Request>();
    }
}