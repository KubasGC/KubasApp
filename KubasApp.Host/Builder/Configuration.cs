using Microsoft.Extensions.Configuration;

namespace KubasApp.Host.Builder;

public partial class CustomHostBuilder
{
    private IConfiguration LoadConfiguration()
    {
        var configurationBuilder = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json", false, true);

        var files = Directory.GetFiles(Directory.GetCurrentDirectory())
            .Where(t => t.Contains(".appsettings.json"));

        foreach (var configFile in files)
        {
            configurationBuilder = configurationBuilder
                .AddJsonFile(configFile, true, true);
        }

        configurationBuilder = configurationBuilder.AddEnvironmentVariables();

        return configurationBuilder.Build();
    }
}