namespace KubasApp.Host.Options;

public class RabbitMqOptions
{
    public bool Enabled { get; set; }
    public HostConfiguration[] Hosts { get; set; }
    public string ApplicationName { get; set; }
    public string VirtualHost { get; set; }
    public string Username { get; set; }
    public string Password { get; set; }

    public class HostConfiguration
    {
        public string Host { get; set; }
        public ushort Port { get; set; }
    }
}