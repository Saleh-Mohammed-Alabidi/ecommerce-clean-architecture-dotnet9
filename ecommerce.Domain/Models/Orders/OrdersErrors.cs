using ErrorOr;

namespace ecommerce.Domain.Models.Orders;

public static class OrdersErrors
{
    public static readonly Error QuantityMustBePositive = Error.Validation(
        code: "Order.QuantityMustBePositive",
        description: "Quantity must be positive.");

    public static readonly Error UnitPriceCannotBeNegative = Error.Validation(
        code: "Order.UnitPriceCannotBeNegative",
        description: "Unit price cannot be negative.");
}