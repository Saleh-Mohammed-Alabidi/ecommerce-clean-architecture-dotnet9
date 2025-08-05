using ErrorOr;
using MediatR;

namespace ecommerce.Application.Products.Commands.Delete;

public record Command(int Id) : IRequest<ErrorOr<Deleted>>;