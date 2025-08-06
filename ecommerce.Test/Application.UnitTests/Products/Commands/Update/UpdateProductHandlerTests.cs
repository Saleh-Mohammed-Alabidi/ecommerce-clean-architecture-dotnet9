namespace ecommerce.Test.Application.Products.Commands.Update;

using ecommerce.Application.Common.Interfaces.Persistence;
using ecommerce.Application.Products.Commands.Update;
using ecommerce.Domain.Models.Products;
using FluentAssertions;
using Moq;
using Xunit;

public class UpdateProductHandlerTests
{
    [Fact]
    public async Task Handle_ShouldUpdateProduct_WhenValid()
    {
        // Arrange
        var mockRepo = new Mock<IProductsRepository>();
        var mockUow = new Mock<IUnitOfWork>();

        var product = Products.Create("Old Name", 50, 1).Value;

        // Mock GetByIdAsync
        mockRepo
            .Setup(r => r.GetByIdAsync(It.IsAny<int>(), It.IsAny<CancellationToken>(), It.IsAny<bool>()))
            .ReturnsAsync(product);

        // Mock CommitChangesAsync
        mockUow
            .Setup(u => u.CommitChangesAsync(It.IsAny<CancellationToken>()))
            .Returns(Task.CompletedTask);

        var handler = new Handler(mockRepo.Object, mockUow.Object);
        var command = new Command(Id: 1, Name: "Updated Name", Price: 100, CategoryId: 2);

        // Act
        var result = await handler.Handle(command, CancellationToken.None);

        // Assert
        result.IsError.Should().BeFalse();
        result.Value.Name.Should().Be("Updated Name");
        result.Value.Price.Should().Be(100);
        result.Value.CategoryId.Should().Be(2);
    }

    [Fact]
    public async Task Handle_ShouldReturnNotFound_WhenProductDoesNotExist()
    {
        // Arrange
        var mockRepo = new Mock<IProductsRepository>();
        var mockUow = new Mock<IUnitOfWork>();

        mockRepo
            .Setup(r => r.GetByIdAsync(It.IsAny<int>(), It.IsAny<CancellationToken>(), It.IsAny<bool>()))
            .ReturnsAsync((Products?)null);

        var handler = new Handler(mockRepo.Object, mockUow.Object);
        var command = new Command(Id: 999, Name: "Updated", Price: 100, CategoryId: 1);

        // Act
        var result = await handler.Handle(command, CancellationToken.None);

        // Assert
        result.IsError.Should().BeTrue();
        result.FirstError.Code.Should().Be("Product.NotFound");
    }
}