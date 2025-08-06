using ecommerce.Application.Products.Queries.GetById;
using Product = ecommerce.Domain.Models.Products.Products;

namespace ecommerce.Api.Features.Products.GetById;

public static class Mapper
{
    public static Query ToCommand(this Request request)
        => new(request.Id);

    public static GetByIdResponse ToResponse(this Product product)
    {
        return new GetByIdResponse(
            Id: product.Id,
            Name: product.Name,
            Price: product.Price,
            CategoryId: product.CategoryId
        );
    }
}