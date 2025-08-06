using ecommerce.Application.Common.Interfaces.Persistence;

namespace ecommerce.Test.Application.Products.Commands.Create;
using ecommerce.Application.Common.Interfaces.Persistence;
using ecommerce.Application.Products.Commands.Create;
using ecommerce.Domain.Models.Products;
using FluentAssertions;
using Moq;
using Xunit;


public class CreateProductHandlerTests
{
    [Fact]
    public async Task Handle_ShouldReturnProduct_WhenValid()
    {
        // Arrange
        var mockRepo = new Mock<IProductsRepository>();
        var mockUow = new Mock<IUnitOfWork>();

        var product = Products.Create("Test Product", 100, 1).Value;

        mockRepo
            .Setup(r => r.AddAsync(It.IsAny<Products>(), default))
            .ReturnsAsync(product);


        var handler = new Handler(mockRepo.Object, mockUow.Object);

        var command = new Command("Test Product", 100, 1);

        // Act
        var result = await handler.Handle(command, default);

        // Assert
        result.IsError.Should().BeFalse();
        result.Value.Name.Should().Be("Test Product");
    }
}