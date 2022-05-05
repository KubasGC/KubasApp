namespace KubasApp.Host.Options;

public class PostgresOptions
{
    public string Host { get; set; }
    public ushort Port { get; set; }
    public string DatabaseName { get; set; }
    public string Username { get; set; }
    public string Password { get; set; }
}