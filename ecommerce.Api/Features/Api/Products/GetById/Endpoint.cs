using ecommerce.Common.Api;
using ecommerce.Common.Behaviors;
using ecommerce.Common.Extensions;
using ErrorOr;
using MediatR;

namespace ecommerce.Api.Features.Products.GetById;

public class Endpoint : BaseApi
{
    public override void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapGet(Router.Products.GetById, async (
                [AsParameters] Request request,
                ISender sender,
                CancellationToken cancellationToken) =>
            {
                var command = request.ToCommand();

                var result = await sender.Send(command, cancellationToken);

                return result.Match(
                    product => Results.Ok(product.ToResponse()),
                    errors => errors.ToProblemDetails());
            })
            .WithValidation<Request>();
    }
}