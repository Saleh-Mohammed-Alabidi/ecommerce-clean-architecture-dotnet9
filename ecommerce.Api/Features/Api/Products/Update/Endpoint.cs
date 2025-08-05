using ecommerce.Common.Api;
using ecommerce.Common.Behaviors;
using ecommerce.Common.Extensions;
using ErrorOr;
using MediatR;

namespace ecommerce.Api.Features.Products.Update;

public class UpdateEndpoint : BaseApi
{
    public override void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapPut(Router.Products.Update, async (
                Request request,
                ISender sender,
                CancellationToken cancellationToken) =>
            {
                var command = request.ToCommand();

                ErrorOr<Domain.Models.Products.Products> result = await sender.Send(command, cancellationToken);

                return result.Match(
                    product => Results.Ok(product),
                    errors => errors.ToProblemDetails());
            })
            .WithName("UpdateProduct")
            .WithValidation<Request>();
    }
}