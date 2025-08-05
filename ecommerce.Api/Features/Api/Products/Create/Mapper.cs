using ecommerce.Application.Products.Commands.Create;

namespace ecommerce.Api.Features.Products.Create;

public static class Mapper
{
    public static Command ToCommand(this Request request)
        => new(request.Name, request.Price, request.CategoryId);
}