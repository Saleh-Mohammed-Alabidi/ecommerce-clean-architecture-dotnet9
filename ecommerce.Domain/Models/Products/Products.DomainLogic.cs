using ErrorOr;

namespace ecommerce.Domain.Models.Products;

public partial class Products
{
    public ErrorOr<Success> SetName(string name)
    {
        if (string.IsNullOrWhiteSpace(name))
            return ProductsErrors.NameIsRequired;

        Name = name.Trim();
        Touch();
        return Result.Success;
    }

    public ErrorOr<Success> SetPrice(decimal price)
    {
        if (price < 0)
            return ProductsErrors.PriceMustBePositive;

        Price = price;
        Touch();
        return Result.Success;
    }

    public ErrorOr<Success> ApplyDiscount(decimal percentage)
    {
        if (percentage <= 0 || percentage > 100)
            return ProductsErrors.InvalidDiscountPercentage;

        var discountAmount = Price * (percentage / 100);
        return SetPrice(Price - discountAmount);
    }

    private void Touch() => UpdateAt = DateTime.UtcNow;
}