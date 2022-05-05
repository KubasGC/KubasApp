using Microsoft.EntityFrameworkCore;
using Serilog;

namespace KubasApp.Database.Services;

public class MigrationService
{
    private readonly DbContext _context;
    private readonly ILogger _logger;

    public MigrationService(DbContext context, ILogger logger)
    {
        _context = context;
        _logger = logger;
    }

    public void MigrateDatabase()
    {
        _logger.Information("Starting Postgres database migration...");
        
        _context.Database.Migrate();

        _logger.Information("Postgres database migration completed");
    }
}