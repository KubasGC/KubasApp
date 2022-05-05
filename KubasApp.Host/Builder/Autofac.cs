using Autofac;
using Autofac.Extensions.DependencyInjection;
using KubasApp.Host.Resources;
using Microsoft.Extensions.Configuration;

namespace KubasApp.Host.Builder;

public partial class CustomHostBuilder
{
    private bool _isContainerConfigured = false;

    private void CheckAutofacConfiguration()
    {
        if (_isContainerConfigured != true)
        {
            throw new Exception(HostMessages.ContainerNotConfigured);
        }
    }
    
    /// <summary>
    /// Adds autofac
    /// </summary>
    /// <returns></returns>
    public CustomHostBuilder AddAutofac(Action<ContainerBuilder> containerBuilderAction = null)
    {
        _hostBuilder.UseServiceProviderFactory(new AutofacServiceProviderFactory());
        _hostBuilder.ConfigureContainer<ContainerBuilder>((_, builder) =>
        {
            builder.RegisterInstance(_configuration).AsSelf().AsImplementedInterfaces().SingleInstance();
            builder.RegisterInstance(ConfigurationRoot).As<IConfiguration>().SingleInstance();
            
            if (containerBuilderAction != null)
            {
                containerBuilderAction(builder);
            }
        });

        _isContainerConfigured = true;

        return this;
    }
}