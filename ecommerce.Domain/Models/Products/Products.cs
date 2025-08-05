using ecommerce.Domain.Common;
using ecommerce.Domain.Models.Categories;
using ErrorOr;

namespace ecommerce.Domain.Models.Products;

public partial class Products : Entity<int>
{
    public string Name { get; private set; }
    public decimal Price { get; private set; }
    public DateTime CreatedAt { get; private set; }
    public DateTime UpdateAt { get; private set; }

    public int CategoryId { get; private set; }

    public virtual Categories.Categories Category { get; set; }

    public virtual ICollection<OrderItems.OrderItems> Items { get; private set; } = new List<OrderItems.OrderItems>();

    // For EF
    private Products()
    {
    }

    private Products(string name, decimal price, int categoryId)
    {
        Name = name;
        Price = price;
        CategoryId = categoryId;
        CreatedAt = DateTime.UtcNow;
        UpdateAt = CreatedAt;
    }

    public static ErrorOr<Products> Create(string name, decimal price, int categoryId)
    {
        if (string.IsNullOrWhiteSpace(name))
            return ProductsErrors.NameIsRequired;

        if (price < 0)
            return ProductsErrors.PriceMustBePositive;

        return new Products(name.Trim(), price, categoryId);
    }

    public void Update(string name, decimal price, int categoryId)
    {
        Name = name;
        Price = price;
        CategoryId = categoryId;
        Touch();
    }
}