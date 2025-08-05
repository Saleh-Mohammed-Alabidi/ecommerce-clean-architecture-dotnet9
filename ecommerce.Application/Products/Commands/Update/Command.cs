using ErrorOr;
using MediatR;

namespace ecommerce.Application.Products.Commands.Update;

public record Command(
    int Id,
    string Name,
    decimal Price,
    int CategoryId
) : IRequest<ErrorOr<Domain.Models.Products.Products>>;