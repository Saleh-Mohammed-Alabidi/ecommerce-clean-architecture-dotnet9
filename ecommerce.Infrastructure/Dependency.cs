using ecommerce.Application.Common.Interfaces.Persistence;
using ecommerce.Infrastructure.Common;
using ecommerce.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;

namespace ecommerce.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services,
        IOptions<databaseOption> dbOptions)
    {
        // DbContext
        services.AddDbContext<EcommerceManagementDbContext>(options =>
        {
            var connectionString = dbOptions.Value.connection;
            options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString))
                .EnableSensitiveDataLogging(false) // Disable sensitive data logging
                .EnableDetailedErrors(false); // Suppress detailed error logs
        });

        // Unit of Work (resolve from DbContext)
        services.AddScoped<IUnitOfWork>(sp =>
            sp.GetRequiredService<EcommerceManagementDbContext>());

        // ecommerce.Infrastructure.DependencyInjection
        services.AddScoped(typeof(GenericDatabaseRepository<,>));

        services.AddMediatR(options =>
        {
            options.RegisterServicesFromAssemblyContaining(typeof(DependencyInjection));
        });


        services.AddScoped<IProductsRepository, ProductsRepository>();
        services.AddScoped<ICategoriesRepository, CategoriesRepository>();
        services.AddScoped<ICustomersRepository, CustomersRepository>();
        services.AddScoped<IOrdersRepository, OrdersRepository>();

        return services;
    }
}