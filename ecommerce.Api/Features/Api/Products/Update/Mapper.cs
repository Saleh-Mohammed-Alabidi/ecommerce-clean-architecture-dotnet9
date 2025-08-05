using ecommerce.Application.Products.Commands.Update;

namespace ecommerce.Api.Features.Products.Update;

public static class Mapper
{
    public static Command ToCommand(this Request request)
        => new(request.Id, request.Name, request.Price, request.CategoryId);
}