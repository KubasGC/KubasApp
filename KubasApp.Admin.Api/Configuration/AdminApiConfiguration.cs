using KubasApp.Host.Options;

namespace KubasApp.Admin.Api.Configuration;

public class AdminApiConfiguration : ConfigurationOptions
{
    public AppOptions App { get; set; }
    public JwtOptions Jwt { get; set; }
}