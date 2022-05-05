using Autofac;
using KubasApp.Database.Context;
using KubasApp.Database.Services;
using Microsoft.EntityFrameworkCore;
using Npgsql;

namespace KubasApp.Host.Builder;

public partial class CustomHostBuilder
{
    public CustomHostBuilder AddPostgres()
    {
        _hostBuilder.ConfigureContainer<ContainerBuilder>((_, builder) =>
        {
            builder.Register(container =>
                {
                    var dbContextOptions = new DbContextOptionsBuilder();

                    var connectionStringBuilder = new NpgsqlConnectionStringBuilder
                    {
                        Database = _configuration.Value.Postgres.DatabaseName,
                        Username = _configuration.Value.Postgres.Username,
                        Host = _configuration.Value.Postgres.Host,
                        Port = _configuration.Value.Postgres.Port,
                        Password = _configuration.Value.Postgres.Password
                    };

                    dbContextOptions = dbContextOptions.UseNpgsql(connectionStringBuilder.ConnectionString);

                    return new PostgresDbContext(dbContextOptions.Options);
                })
                .AsSelf()
                .As<DbContext>()
                .InstancePerLifetimeScope();

            builder.RegisterType<MigrationService>().InstancePerLifetimeScope();
        });

        return this;
    }
}