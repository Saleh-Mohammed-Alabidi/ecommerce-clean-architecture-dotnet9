using ecommerce.Application.Common.Interfaces.Persistence;
using ecommerce.Domain.Models.Products;
using ErrorOr;
using MediatR;

namespace ecommerce.Application.Products.Commands.Delete;

public class Handler(
    IProductsRepository productsRepository,
    IUnitOfWork unitOfWork)
    : IRequestHandler<Command, ErrorOr<Deleted>>
{
    public async Task<ErrorOr<Deleted>> Handle(Command request, CancellationToken cancellationToken)
    {
        var product = await productsRepository.GetByIdAsync(request.Id, cancellationToken);

        if (product is null)
        {
            return ProductsErrors.NotFound(request.Id);
        }

        productsRepository.Delete(product, cancellationToken);
        await unitOfWork.CommitChangesAsync(cancellationToken);

        return Result.Deleted;
    }
}