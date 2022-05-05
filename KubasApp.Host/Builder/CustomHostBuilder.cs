using KubasApp.Host.Options;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Options;

namespace KubasApp.Host.Builder;

public partial class CustomHostBuilder
{
    public static IConfiguration ConfigurationRoot { get; private set; }
    private readonly IHostBuilder _hostBuilder;
    private readonly IOptions<ConfigurationOptions> _configuration;
    private CustomHostBuilder(IHostBuilder hostBuilder)
    {
        _hostBuilder = hostBuilder;
        ConfigurationRoot = LoadConfiguration();
        _configuration = Microsoft.Extensions.Options.Options.Create(ConfigurationRoot.Get<ConfigurationOptions>());
    }

    /// <summary>
    /// Create instance of CustomHostBuilder
    /// </summary>
    /// <returns></returns>
    public static CustomHostBuilder Create(IHostBuilder builder) => new(builder);

    /// <summary>
    /// Return IHostBuilder
    /// </summary>
    /// <returns></returns>
    public IHostBuilder Build()
        => _hostBuilder;
}