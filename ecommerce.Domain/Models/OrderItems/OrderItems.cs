using ecommerce.Domain.Common;

namespace ecommerce.Domain.Models.OrderItems;

public class OrderItems : Entity<int>
{
    public int ProductId { get; private set; }
    public decimal UnitPrice { get; private set; }
    public int Quantity { get; private set; }
    public int OrderId { get; private set; }

    public DateTime CreatedAt { get; private set; }
    public DateTime UpdateAt { get; private set; }

    public virtual Orders.Orders Order { get; set; }
    
    public virtual Products.Products Product { get; set; }

    // For EF
    private OrderItems()
    {
    }

    public OrderItems(int productId, decimal unitPrice, int quantity,int orderId)
    {
        ProductId = productId;
        UnitPrice = unitPrice;
        Quantity = quantity;
        OrderId = orderId;
        CreatedAt = DateTime.UtcNow;
        UpdateAt = DateTime.UtcNow;
    }
}