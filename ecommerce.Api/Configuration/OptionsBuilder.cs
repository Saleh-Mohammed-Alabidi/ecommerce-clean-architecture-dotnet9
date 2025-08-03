using ecommerce.Common.Configuration.Constrain;
using FluentValidation;


public static class OptionsBuilderExtensions
{
    /// <summary>
    ///     Now every time you add option and file json in Configuration files
    ///     1- register the files json in addConfigurationFiles
    ///     2- create class option such as (databaseOption) and there validation
    ///     3- add  Options in services
    /// </summary>
    /// <returns></returns>
    public static IConfigurationManager addConfigurationFiles(this IConfigurationManager config,
        WebApplicationBuilder builder)
    {
        config.AddJsonFile("Configuration/json/RateLimit.json", true, true);
        config.AddJsonFile($"Configuration/json/RateLimit.{builder.Environment.EnvironmentName}.json", true,
            true);

        return config;
    }

    public static IServiceCollection AddOptions(this IServiceCollection services, WebApplicationBuilder builder)
    {
        services.AddSingleton<IValidator<RateLimitConstrain>, RateLimitConstrainsValidator>();
        return services;
    }
}