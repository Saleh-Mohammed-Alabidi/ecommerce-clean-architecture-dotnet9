namespace ecommerce.Api.Features.Products.Update;

public record Request(int Id, string Name, decimal Price, int CategoryId);