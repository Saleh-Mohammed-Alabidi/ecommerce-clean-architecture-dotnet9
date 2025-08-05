using ecommerce.Domain.Common;
using ErrorOr;

namespace ecommerce.Domain.Models.Orders;

public partial class Orders : Entity<int>
{
    public int CustomerId { get; private set; }
    public DateTime CreatedAt { get; private set; }
    public DateTime UpdateAt { get; private set; }

    public virtual ICollection<OrderItems.OrderItems> Items { get; private set; } = new List<OrderItems.OrderItems>();

    public virtual Customers.Customers Customer { get; private set; }


    private Orders()
    {
    } // For EF

    public Orders(int customerId)
    {
        CustomerId = customerId;
        CreatedAt = DateTime.UtcNow;
        UpdateAt = DateTime.UtcNow;
    }

    public ErrorOr<Success> AddItem(int productId, decimal unitPrice, int quantity)
    {
        if (quantity <= 0)
            return OrdersErrors.QuantityMustBePositive;

        if (unitPrice < 0)
            return OrdersErrors.UnitPriceCannotBeNegative;

        Items.Add(new OrderItems.OrderItems(productId, unitPrice, quantity, Id));
        return Result.Success;
    }

    public decimal GetTotal() => Items.Sum(i => i.UnitPrice * i.Quantity);
}