using ErrorOr;

namespace ecommerce.Domain.Models.Products;

public static class ProductsErrors
{
    public static readonly Error NameIsRequired = Error.Validation(
        code: "Product.NameIsRequired",
        description: "Product name is required.");

    public static readonly Error PriceMustBePositive = Error.Validation(
        code: "Product.PriceMustBePositive",
        description: "Product price must be greater than or equal to zero.");

    public static readonly Error InvalidDiscountPercentage = Error.Validation(
        code: "Product.InvalidDiscountPercentage",
        description: "Discount must be between 0 and 100.");
    
    public static Error NotFound(int id) => Error.NotFound(
        code: "Product.NotFound",
        description: $"Product with ID {id} was not found.");
}