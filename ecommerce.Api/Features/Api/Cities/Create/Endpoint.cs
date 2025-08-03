using ecommerce.Common.Api;

namespace ecommerce.Api.Features.Cities.Create;

public class Endpoint : BaseApi
{
    public override void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapPost(Router.Cities.Create, (Request request) =>
        {
            return Results.Created(Router.Cities.Get, request.Name);
        });
    }
}