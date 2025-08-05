namespace ecommerce.Features.Api;

using FluentValidation;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

public static class DependencyInjection
{
    public static IServiceCollection AddValidators(this IServiceCollection services)
    {
        // Register all validators from the assembly that contains this class
        services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());

        // If you want to register from multiple assemblies, add them here:
        // services.AddValidatorsFromAssembly(typeof(SomeValidatorInAnotherAssembly).Assembly);

        return services;
    }
}
