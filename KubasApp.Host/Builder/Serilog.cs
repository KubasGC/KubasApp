using Autofac;
using Serilog;
using Serilog.Events;

namespace KubasApp.Host.Builder;

public partial class CustomHostBuilder
{
    public CustomHostBuilder AddSerilog()
    {
        CheckAutofacConfiguration();

        var loggerBuilder = new LoggerConfiguration()
            .Enrich.FromLogContext()
            .WriteTo.Console(restrictedToMinimumLevel: LogEventLevel.Information);
            
        if (_configuration.Value.Serilog.File.Enabled)
        {
            loggerBuilder = loggerBuilder.WriteTo.File(_configuration.Value.Serilog.File.Path,
                restrictedToMinimumLevel: LogEventLevel.Information);
        }

        if (_configuration.Value.Serilog.Sentry.Enabled)
        {
            loggerBuilder = loggerBuilder.WriteTo.Sentry(_configuration.Value.Serilog.Sentry.Dsn);
        }

        if (_configuration.Value.Serilog.Seq.Enabled)
        {
            loggerBuilder = loggerBuilder.WriteTo.Seq(_configuration.Value.Serilog.Seq.Url);
        }

        var logger = loggerBuilder.CreateLogger();
        Log.Logger = logger;

        _hostBuilder.ConfigureContainer<ContainerBuilder>((_, builder) =>
        {
            builder.RegisterInstance(logger)
                .AsSelf()
                .AsImplementedInterfaces()
                .SingleInstance();
        });

        _hostBuilder.UseSerilog(logger);
        
        return this;
    }
}