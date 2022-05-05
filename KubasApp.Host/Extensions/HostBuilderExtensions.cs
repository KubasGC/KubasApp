using KubasApp.Host.Builder;
using Microsoft.Extensions.Hosting;

namespace KubasApp.Host.Extensions;

public static class HostBuilderExtensions
{
    public static CustomHostBuilder AddCustomHostBuilder(this IHostBuilder builder)
        => CustomHostBuilder.Create(builder);
}