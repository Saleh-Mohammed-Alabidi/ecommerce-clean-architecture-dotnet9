using ecommerce.Application.Products.Commands.Delete;

namespace ecommerce.Api.Features.Products.Delete;

public static class Mapper
{
    public static Command ToCommand(this Request request)
        => new(request.Id);
}