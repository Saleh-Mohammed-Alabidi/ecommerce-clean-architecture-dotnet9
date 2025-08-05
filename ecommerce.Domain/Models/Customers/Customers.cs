using ecommerce.Domain.Common;

namespace ecommerce.Domain.Models.Customers;

public partial class Customers : Entity<int>
{
    public string FullName { get; private set; }
    public string Email { get; private set; }

    public DateTime CreatedAt { get; private set; }
    public DateTime UpdateAt { get; private set; }

    public virtual ICollection<Orders.Orders> Orders { get; set; } = new List<Orders.Orders>();


    // For EF
    private Customers()
    {
    }

    public Customers(string fullName, string email)
    {
        FullName = fullName;
        Email = email;
    }
}