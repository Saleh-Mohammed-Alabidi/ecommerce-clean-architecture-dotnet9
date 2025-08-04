using Carter;
using ecommerce.Api.Features.Cities.Create;
using ecommerce.Application;
using ecommerce.Common.Configuration.Constrain;
using ecommerce.Common.Extensions;
using ecommerce.Common.Logger;
using ecommerce.Common.Middleware;
using ecommerce.Infrastructure;
using EloroShop.Api.Common.Filters;
using FluentValidation;
using Microsoft.Extensions.Options;
using Scalar.AspNetCore;


var builder = WebApplication.CreateBuilder(args);

// ✅ Generic logger init
Logging.InitializeLogger();

// Add services to the container.
builder.Services.AddOpenApi();

// carter
builder.Services.AddCarter();

// option pattern
builder.Configuration.addConfigurationFiles(builder);
builder.Services.AddOptions(builder);

var services = builder.Services.BuildServiceProvider();

//Rate Limit
var rateLimitOption = services.GetRequiredService<IOptions<RateLimitConstrain>>();
builder.Services.AddRateLimitPolicy(rateLimitOption);

// Authorization
builder.Services.AddAuthorizationPolicy();

// Authentication
var jwtOptions = services.GetRequiredService<IOptions<jwtOption>>();
builder.Services.AddAuthentication(jwtOptions);


// add AddInfrastructure
var dbOptions = services.GetRequiredService<IOptions<databaseOption>>();
builder.Services.AddInfrastructure(dbOptions);
builder.Services.AddApplication();

// Filter IEndpoint
builder.Services.AddScoped(typeof(LoggingFilter));

// MediatR
builder.Services.AddMediatR(cfg =>
{
    cfg.RegisterServicesFromAssemblyContaining(typeof(Program)); // Your API layer or main assembly
});

builder.Services.AddValidatorsFromAssemblyContaining<Validator>(); // Your validator class


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.MapScalarApiReference();
}


app.UseHttpsRedirection()
    .UseAuthentication()
    .UseAuthorization()
    .UseRateLimiter();

app.UseMiddleware<CustomMiddleware>();
app.MapCarter();

// start 
app.Run();