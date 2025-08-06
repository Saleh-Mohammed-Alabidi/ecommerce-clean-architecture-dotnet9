namespace ecommerce.Test.Application.Products.Commands.Delete;

using ecommerce.Application.Products.Commands.Delete;
using ecommerce.Application.Common.Interfaces.Persistence;
using ecommerce.Domain.Models.Products;
using ErrorOr;
using FluentAssertions;
using Moq;
using Xunit;

public class DeleteProductHandlerTests
{
    [Fact]
    public async Task Handle_ShouldReturnDeleted_WhenProductExists()
    {
        // Arrange
        var mockRepo = new Mock<IProductsRepository>();
        var mockUow = new Mock<IUnitOfWork>();

        var existingProduct = Products.Create("ToDelete", 123, 1).Value;

        mockRepo
            .Setup(r => r.GetByIdAsync(It.IsAny<int>(), It.IsAny<CancellationToken>(), It.IsAny<bool>()))
            .ReturnsAsync(existingProduct);

        mockRepo.Setup(r => r.Delete(It.IsAny<Products>(), default));

        mockUow.Setup(u => u.CommitChangesAsync(It.IsAny<CancellationToken>()))
            .Returns(Task.CompletedTask);

        var handler = new Handler(mockRepo.Object, mockUow.Object);
        var command = new Command(Id: 1);

        // Act
        var result = await handler.Handle(command, CancellationToken.None);

        // Assert
        result.IsError.Should().BeFalse();
        result.Value.Should().Be(Result.Deleted);

        mockRepo.Verify(r => r.Delete(existingProduct, It.IsAny<CancellationToken>()), Times.Once);
        mockUow.Verify(u => u.CommitChangesAsync(It.IsAny<CancellationToken>()), Times.Once);
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
        var command = new Command(Id: 999);

        // Act
        var result = await handler.Handle(command, CancellationToken.None);

        // Assert
        result.IsError.Should().BeTrue();
        result.FirstError.Code.Should().Be("Product.NotFound");

        mockRepo.Verify(r => r.Delete(It.IsAny<Products>(), It.IsAny<CancellationToken>()), Times.Never);
        mockUow.Verify(u => u.CommitChangesAsync(It.IsAny<CancellationToken>()), Times.Never);
    }
}