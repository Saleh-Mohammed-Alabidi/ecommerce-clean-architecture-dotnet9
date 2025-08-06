using ecommerce.Common.Api;
using ecommerce.Common.Behaviors;
using ecommerce.Common.Extensions;
using ErrorOr;
using MediatR;

namespace ecommerce.Api.Features.Products.Create;

public class Endpoint : BaseApi
{
    public override void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapPost(Router.Products.Create, async (
                Request request,
                ISender sender,
                CancellationToken token) =>
            {
                var command = request.ToCommand();

                var result = await sender.Send(command, token);

                return result.Match(
                    product => Results.Created($"/products/{product.Id}", product),
                    errors => errors.ToProblemDetails());
            })
            .WithValidation<Request>();
    }
}