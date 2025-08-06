using MediatR;
using ErrorOr;
namespace ecommerce.Application.Products.Commands.Create;

using ecommerce.Domain.Models.Products;

public record Command(string Name, decimal Price, int CategoryId)
    : IRequest<ErrorOr<Products>>;
