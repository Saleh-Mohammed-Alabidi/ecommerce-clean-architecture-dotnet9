using ecommerce.Domain.Common;

namespace ecommerce.Domain.Models.Categories;

public partial class Categories : Entity<int>
{
    public string Name { get; private set; }

    public DateTime CreatedAt { get; private set; }
    public DateTime UpdateAt { get; private set; }

    public virtual ICollection<Products.Products> Products { get; set; } = new List<Products.Products>();

    // For EF
    private Categories()
    {
    }

    public Categories(string name)
    {
        Name = name;
    }
}