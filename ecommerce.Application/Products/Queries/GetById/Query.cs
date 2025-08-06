using MediatR;
using ErrorOr;

namespace ecommerce.Application.Products.Queries.GetById;

public record Query(int Id)
    : IRequest<ErrorOr<Domain.Models.Products.Products>>;