using Autofac;
using EasyNetQ;
using EasyNetQ.DI;
using EasyNetQ.Logging;
using Serilog;

namespace KubasApp.Host.Builder;

public partial class CustomHostBuilder
{
    public CustomHostBuilder AddRabbitMq(Action<IServiceRegister> serviceRegistration = null)
    {
        CheckAutofacConfiguration();

        if (_configuration.Value.RabbitMq.Enabled != true)
        {
            return this;
        }

        var connectionConfiguration = new ConnectionConfiguration
        {
            Hosts = _configuration.Value.RabbitMq.Hosts
                .Select(t => new HostConfiguration
                {
                    Host = t.Host,
                    Port = t.Port
                })
                .ToList(),
            Port = _configuration.Value.RabbitMq.Hosts.First().Port,
            Name = _configuration.Value.RabbitMq.ApplicationName,
            Password = _configuration.Value.RabbitMq.Password,
            UserName = _configuration.Value.RabbitMq.Username,
            VirtualHost = _configuration.Value.RabbitMq.VirtualHost
        };

        _hostBuilder.ConfigureContainer<ContainerBuilder>((_, builder) =>
        {
            builder.Register(t => RabbitHutch.CreateBus(connectionConfiguration, register =>
                {
                    if (serviceRegistration != null)
                    {
                        serviceRegistration(register);
                    }
                }))
                .As<IBus>()
                .SingleInstance();
        });

        return this;
    }
}