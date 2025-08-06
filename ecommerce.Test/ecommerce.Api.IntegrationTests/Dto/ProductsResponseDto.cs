
public class ProductsResponseDto
{
    public int Id { get; set; }
    public string Name { get; set; } = default!;
    public decimal Price { get; set; }
    public int CategoryId { get; set; }
}