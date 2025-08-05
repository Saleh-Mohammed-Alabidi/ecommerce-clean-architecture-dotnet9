using ecommerce.Application.Common.Interfaces.Persistence;
using ErrorOr;
using MediatR;
using Product = ecommerce.Domain.Models.Products.Products;

namespace ecommerce.Application.Products.Commands.Create;

public class Handler(
    IProductsRepository productsRepository,
    IUnitOfWork unitOfWork)
    : IRequestHandler<Command, ErrorOr<Product>>
{
    public async Task<ErrorOr<Product>> Handle(Command request,
        CancellationToken cancellationToken)
    {
        // Domain validation
        var createResult = Product.Create(
            request.Name, request.Price, request.CategoryId);

        if (createResult.IsError)
        {
            return createResult.Errors;
        }

        var product = createResult.Value;

        await productsRepository.AddAsync(product, cancellationToken);
        await unitOfWork.CommitChangesAsync(cancellationToken);

        return product;
    }
}