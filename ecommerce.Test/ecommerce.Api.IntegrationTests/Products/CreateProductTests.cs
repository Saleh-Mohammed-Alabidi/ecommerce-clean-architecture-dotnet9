using ecommerce.Common.Api;

namespace ecommerce.Api.IntegrationTests.Products;

using System.Net;
using System.Net.Http.Json;
using ecommerce.Api.Features.Products.Create;
using ecommerce.Api.IntegrationTests.Utilities;
using FluentAssertions;
using Xunit;

public class CreateProductTests : IClassFixture<CustomWebApplicationFactory>
{
    private readonly HttpClient _client;

    public CreateProductTests(CustomWebApplicationFactory factory)
    {
        _client = factory.CreateClient();
    }

    [Fact]
    public async Task CreateProduct_ShouldReturnCreated_WhenRequestIsValid()
    {
        // Arrange
        var request = new Request("Test Product", 100, 1);

        // Act
        var response = await _client.PostAsJsonAsync(Router.Products.Create, request);

        // Assert
        response.StatusCode.Should().Be(HttpStatusCode.Created);

        var responseContent = await response.Content.ReadFromJsonAsync<ProductsResponseDto>();
        responseContent.Should().NotBeNull();
        responseContent!.Name.Should().Be("Test Product");
    }
}