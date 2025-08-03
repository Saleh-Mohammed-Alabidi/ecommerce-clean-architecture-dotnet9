using Serilog;

namespace ecommerce.Common.Logger;

public static class Logging
{
    public static void InitializeLogger(string configFile = "appsettings.json")
    {
        var configuration = new ConfigurationBuilder()
            .AddJsonFile(configFile, optional: false, reloadOnChange: true)
            .Build();

        Log.Logger = new LoggerConfiguration()
            .ReadFrom.Configuration(configuration)
            .Enrich.FromLogContext()
            .WriteTo.Console()
            .CreateLogger();
    }
}