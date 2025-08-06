namespace ecommerce.Api.Features.Products.GetById;

public record GetByIdResponse(
    int Id,
    string Name,
    decimal Price,
    int CategoryId
);