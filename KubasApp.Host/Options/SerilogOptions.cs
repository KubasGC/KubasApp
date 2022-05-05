namespace KubasApp.Host.Options;

public class SerilogOptions
{
    /// <summary>
    /// Seq options
    /// </summary>
    public SeqOptions Seq { get; set; }

    /// <summary>
    /// Sentry options
    /// </summary>
    public SentryOptions Sentry { get; set; }
    
    /// <summary>
    /// File options
    /// </summary>
    public FileOptions File { get; set; }

    public class FileOptions
    {
        public bool Enabled { get; set; }
        public string Path { get; set; }
    }


    public class SentryOptions
    {
        public bool Enabled { get; set; }
        public string Dsn { get; set; }
    }

    public class SeqOptions
    {
        public bool Enabled { get; set; }
        public string Url { get; set; }
    }
}