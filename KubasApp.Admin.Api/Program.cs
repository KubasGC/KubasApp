using Autofac;
using Autofac.Extensions.DependencyInjection;
using KubasApp.Admin.Api.Configuration;
using KubasApp.Admin.Api.Extensions;
using KubasApp.Database.Services;
using KubasApp.Host.Builder;
using KubasApp.Host.Extensions;
using Microsoft.Extensions.Options;

var builder = WebApplication.CreateBuilder(args);

builder.Host
    .AddCustomHostBuilder()
    .AddAutofac(autofacBuilder =>
    {
        autofacBuilder.Register(t =>
            {
                var ctx = t.Resolve<IComponentContext>();
                var conf = ctx.Resolve<IConfiguration>();

                return Options.Create(conf.Get<AdminApiConfiguration>());
            })
            .AsSelf()
            .SingleInstance();
    })
    .AddSerilog()
    .AddRabbitMq()
    .AddPostgres()
    .Build();

builder.Services.AddControllers();
builder.Services.AddSwaggerGen();
builder.Services.AddJwtAuth();

builder.WebHost.ConfigureKestrel(configuration =>
{
    configuration.ListenAnyIP(CustomHostBuilder.ConfigurationRoot.GetValue<int>("App:Port"));
    configuration.AddServerHeader = false;
});

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app
        .UseDeveloperExceptionPage()
        .UseSwagger()
        .UseSwaggerUI();
}

app.MapControllers();
app.UseAuthentication();
app.UseAuthorization();


using (var scope = app.Services.GetAutofacRoot().BeginLifetimeScope())
{
    var migrationService = scope.Resolve<MigrationService>();
    migrationService.MigrateDatabase();
}

app.Run();