namespace ecommerce.Test.Application.Products.Queries.GetById;

using ecommerce.Application.Products.Queries.GetById;
using ecommerce.Application.Common.Interfaces.Persistence;
using ecommerce.Domain.Models.Products;
using ErrorOr;
using FluentAssertions;
using Moq;
using Xunit;

public class GetByIdProductHandlerTests
{
    [Fact]
    public async Task Handle_ShouldReturnProduct_WhenProductExists()
    {
        // Arrange
        var mockRepo = new Mock<IProductsRepository>();
        var product = Products.Create("Sample", 99.99m, 1).Value;

        mockRepo
            .Setup(r => r.GetByIdAsync(It.IsAny<int>(), It.IsAny<CancellationToken>(), It.IsAny<bool>()))
            .ReturnsAsync(product);

        var handler = new Handler(mockRepo.Object);
        var query = new Query(Id: 1);

        // Act
        var result = await handler.Handle(query, CancellationToken.None);

        // Assert
        result.IsError.Should().BeFalse();
        result.Value.Should().Be(product);
    }

    [Fact]
    public async Task Handle_ShouldReturnNotFoundError_WhenProductDoesNotExist()
    {
        // Arrange
        var mockRepo = new Mock<IProductsRepository>();

        mockRepo
            .Setup(r => r.GetByIdAsync(It.IsAny<int>(), It.IsAny<CancellationToken>(), It.IsAny<bool>()))
            .ReturnsAsync((Products?)null);

        var handler = new Handler(mockRepo.Object);
        var query = new Query(Id: 999);

        // Act
        var result = await handler.Handle(query, CancellationToken.None);

        // Assert
        result.IsError.Should().BeTrue();
        result.FirstError.Code.Should().Be("Product.NotFound");

        // Optional: verify GetByIdAsync was called
        mockRepo.Verify(r => r.GetByIdAsync(999, It.IsAny<CancellationToken>(), It.IsAny<bool>()), Times.Once);
    }
}