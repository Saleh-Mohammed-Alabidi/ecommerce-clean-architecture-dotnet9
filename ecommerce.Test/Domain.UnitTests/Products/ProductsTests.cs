namespace ecommerce.Test.Domain.Models.Products;

using ecommerce.Domain.Models.Products;
using FluentAssertions;
using Xunit;

public class ProductsTests
{
    [Fact]
    public void Create_ShouldReturnProduct_WhenValidData()
    {
        // Act
        var result = Products.Create("Product 1", 100m, 1);

        // Assert
        result.IsError.Should().BeFalse();
        result.Value.Name.Should().Be("Product 1");
        result.Value.Price.Should().Be(100m);
        result.Value.CategoryId.Should().Be(1);
        result.Value.CreatedAt.Should().BeCloseTo(DateTime.UtcNow, TimeSpan.FromSeconds(5));
    }

    [Theory]
    [InlineData("")]
    [InlineData("   ")]
    public void Create_ShouldReturnError_WhenNameIsInvalid(string name)
    {
        // Act
        var result = Products.Create(name, 100m, 1);

        // Assert
        result.IsError.Should().BeTrue();
        result.FirstError.Code.Should().Be("Product.NameIsRequired");
    }

    [Fact]
    public void Create_ShouldReturnError_WhenPriceIsNegative()
    {
        // Act
        var result = Products.Create("Test", -10m, 1);

        // Assert
        result.IsError.Should().BeTrue();
        result.FirstError.Code.Should().Be("Product.PriceMustBePositive");
    }

    [Fact]
    public void Update_ShouldChangeProductValues()
    {
        // Arrange
        var product = Products.Create("Old", 50m, 1).Value;
        var oldUpdatedAt = product.UpdateAt;

        // Act
        product.Update("New Name", 200m, 2);

        // Assert
        product.Name.Should().Be("New Name");
        product.Price.Should().Be(200m);
        product.CategoryId.Should().Be(2);
        product.UpdateAt.Should().BeAfter(oldUpdatedAt);
    }
}