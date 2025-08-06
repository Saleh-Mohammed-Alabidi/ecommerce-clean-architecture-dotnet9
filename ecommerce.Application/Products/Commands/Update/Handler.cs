using ecommerce.Application.Common.Interfaces.Persistence;
using ecommerce.Domain.Models.Products;
using ErrorOr;
using MediatR;

namespace ecommerce.Application.Products.Commands.Update;

public class Handler(
    IProductsRepository productsRepository,
    IUnitOfWork unitOfWork)
    : IRequestHandler<Command, ErrorOr<Domain.Models.Products.Products>>
{
    public async Task<ErrorOr<Domain.Models.Products.Products>> Handle(Command request,
        CancellationToken cancellationToken)
    {
        var product = await productsRepository.GetByIdAsync(request.Id, cancellationToken, false);

        if (product is null)
            return ProductsErrors.NotFound(request.Id);

        // Apply update
        product.Update(request.Name.Trim(), request.Price, request.CategoryId);

        await unitOfWork.CommitChangesAsync(cancellationToken);


        return product;
    }
}