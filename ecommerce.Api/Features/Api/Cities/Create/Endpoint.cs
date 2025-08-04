using ecommerce.Common.Api;
using ecommerce.Common.Behaviors;
using ecommerce.Common.Extensions;
using ErrorOr;

namespace ecommerce.Api.Features.Cities.Create;

public class Endpoint : BaseApi
{
    public override void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapPost(Router.Cities.Create, async (Request request) =>
        {
            return Results.Created(Router.Cities.Get, request.Name);
        }).WithValidation<Request>();
    }
}