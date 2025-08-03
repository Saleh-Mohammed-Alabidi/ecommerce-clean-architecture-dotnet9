using Carter;
using ecommerce.Common.Configuration.Constrain;
using ecommerce.Common.Extensions;
using ecommerce.Common.Logger;
using ecommerce.Infrastructure;
using EloroShop.Api.Common.Filters;
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


// MediatR
builder.Services.AddMediatR(options => { options.RegisterServicesFromAssemblyContaining(typeof(Program)); });

// add AddInfrastructure
var dbOptions = services.GetRequiredService<IOptions<databaseOption>>();
builder.Services.AddInfrastructure(dbOptions);


// Filter IEndpoint
builder.Services.AddScoped(typeof(LoggingFilter));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.MapScalarApiReference();
}

app.UseHttpsRedirection();

//Authorization
app.UseAuthorization();
// Authentication
app.UseAuthentication();
// Rate Limit
app.UseRateLimiter();
// map carter
app.MapCarter();


// start 
app.Run();