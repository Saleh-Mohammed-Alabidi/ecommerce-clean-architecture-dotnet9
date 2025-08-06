using ErrorOr;
using MediatR;

namespace ecommerce.Application.Products.Commands.Update;

using ecommerce.Domain.Models.Products;
public record Command(
    int Id,
    string Name,
    decimal Price,
    int CategoryId
) : IRequest<ErrorOr<Products>>;