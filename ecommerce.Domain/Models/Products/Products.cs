using ecommerce.Domain.Common;

namespace ecommerce.Domain.Models.Products;

public partial class Products : Entity<int>
{
    public required string Name { get; set; }
    public required decimal Price { get; set; }
    
    public required DateTime CreatedAt { get; set; }
    
    public required DateTime UpdateAt { get; set; }
}