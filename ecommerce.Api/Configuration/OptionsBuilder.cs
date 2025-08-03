using ecommerce.Common.Configuration.Constrain;
using FluentValidation;
using Microsoft.Extensions.Options;


public static class OptionsBuilderExtensions
{
    /// <summary>
    ///     Now every time you add option and file json in Configuration files
    ///     1- register the files json in addConfigurationFiles
    ///     2- create class option such as (databaseOption) and there validation
    ///     3- add  Options in services
    /// </summary>
    /// <returns></returns>
    
    public static OptionsBuilder<TOptions> ValidateFluently<TOptions>(
        this OptionsBuilder<TOptions> optionsBuilder) where TOptions : class
    {
        optionsBuilder.Services.AddSingleton<IValidateOptions<TOptions>>(sp =>
        {
            var validator = sp.GetRequiredService<IValidator<TOptions>>();
            return new FluentValidationOptions<TOptions>(validator);
        });


        return optionsBuilder;
    }
    
    public static IConfigurationManager addConfigurationFiles(this IConfigurationManager config,
        WebApplicationBuilder builder)
    {
        config.AddJsonFile("Configuration/json/RateLimit.json", true, true);
        config.AddJsonFile($"Configuration/json/RateLimit.{builder.Environment.EnvironmentName}.json", true,
            true);

        config.AddJsonFile("Configuration/json/JWT.json", true, true);
        config.AddJsonFile($"Configuration/json/JWT.{builder.Environment.EnvironmentName}.json", true,
            true);

        return config;
    }

    public static IServiceCollection AddOptions(this IServiceCollection services, WebApplicationBuilder builder)
    {
        services.AddSingleton<IValidator<RateLimitConstrain>, RateLimitConstrainsValidator>();
        services.AddSingleton<IValidator<jwtOption>, jwtValidator>();
        
        // bind service

        services.AddOptions<RateLimitConstrain>().Bind(builder.Configuration)
            .ValidateFluently().ValidateOnStart();
        
        services.AddOptions<jwtOption>().Bind(builder.Configuration)
            .ValidateFluently().ValidateOnStart();

        return services;
    }
}