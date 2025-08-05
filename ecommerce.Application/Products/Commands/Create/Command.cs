using MediatR;
using ErrorOr;

namespace ecommerce.Application.Products.Commands.Create;

public record Command(string Name, decimal Price, int CategoryId)
    : IRequest<ErrorOr<Domain.Models.Products.Products>>;
