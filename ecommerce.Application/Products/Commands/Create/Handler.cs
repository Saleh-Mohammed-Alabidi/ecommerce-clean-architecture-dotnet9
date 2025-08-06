using ecommerce.Application.Common.Interfaces.Persistence;
using ErrorOr;
using MediatR;

namespace ecommerce.Application.Products.Commands.Create;

using ecommerce.Domain.Models.Products;

public class Handler(
    IProductsRepository productsRepository,
    IUnitOfWork unitOfWork)
    : IRequestHandler<Command, ErrorOr<Products>>
{
    public async Task<ErrorOr<Products>> Handle(Command request,
        CancellationToken cancellationToken)
    {
        // Domain validation
        var createResult = Products.Create(
            request.Name, request.Price, request.CategoryId);

        if (createResult.IsError)
            return createResult.Errors;

        var product = createResult.Value;

        await productsRepository.AddAsync(product, cancellationToken);
        await unitOfWork.CommitChangesAsync(cancellationToken);

        return product;
    }
}