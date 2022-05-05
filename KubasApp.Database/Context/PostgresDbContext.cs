using KubasApp.Database.DbModels;
using Microsoft.EntityFrameworkCore;

namespace KubasApp.Database.Context;

public class PostgresDbContext : DbContext
{
    public DbSet<UserDbModel> Users { get; set; }

    public PostgresDbContext()
    {
        
    }
    public PostgresDbContext(DbContextOptions options) : base(options)
    {
        
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (optionsBuilder.IsConfigured != true)
        {
            optionsBuilder.UseNpgsql();
        }
    }
}