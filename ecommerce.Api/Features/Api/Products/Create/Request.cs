namespace ecommerce.Api.Features.Products.Create;

public record Request(string Name, decimal Price, int CategoryId);
