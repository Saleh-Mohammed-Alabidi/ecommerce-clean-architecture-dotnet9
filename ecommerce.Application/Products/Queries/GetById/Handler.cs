using ecommerce.Application.Common.Interfaces.Persistence;
using ecommerce.Domain.Models.Products;
using ErrorOr;
using MediatR;
using Product = ecommerce.Domain.Models.Products.Products;

namespace ecommerce.Application.Products.Queries.GetById;

public class Handler(IProductsRepository productsRepository)
    : IRequestHandler<Query, ErrorOr<Product>>
{
    public async Task<ErrorOr<Product>> Handle(Query request, CancellationToken cancellationToken)
    {
        var product = await productsRepository.GetByIdAsync(request.Id, cancellationToken);

        if (product is null)
            return ProductsErrors.NotFound(request.Id);

        return product;
    }
}