using ecommerce.Common.Api;
using ecommerce.Common.Behaviors;
using ecommerce.Common.Extensions;
using ErrorOr;
using MediatR;

namespace ecommerce.Api.Features.Products.Delete;

public class Endpoint : BaseApi
{
    public override void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapDelete(Router.Products.Delete, async (
                [AsParameters] Request request,
                ISender sender,
                CancellationToken cancellationToken) =>
            {
                var command = request.ToCommand();

                var result = await sender.Send(command, cancellationToken);

                return result.Match(
                    product => Results.Ok(product),
                    errors => errors.ToProblemDetails());
            })
            .WithValidation<Request>();
    }
}