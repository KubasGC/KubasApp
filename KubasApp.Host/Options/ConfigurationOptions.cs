namespace KubasApp.Host.Options;

public class ConfigurationOptions
{
    public PostgresOptions Postgres { get; set; }
    public SerilogOptions Serilog { get; set; }
    public RabbitMqOptions RabbitMq { get; set; }
}