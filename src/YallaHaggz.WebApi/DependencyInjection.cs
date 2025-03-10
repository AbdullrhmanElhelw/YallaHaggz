namespace YallaHaggz.WebApi;

using Domain;
using Domain.Abstractions;
using Domain.Data;
using Domain.Entities.Roles;
using Domain.Entities.Users;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Serilog;
using Serilog.Sinks.MSSqlServer;
using Services;

public static class DependencyInjection
{
    public static IServiceCollection AddWebApi(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDomain(configuration);
        services.AddIdentity();
        services.AddServices(configuration);
        return services;
    }

    public static IHostBuilder AddSerilog(
      this IHostBuilder builder,
      IConfiguration configuration)
    {
        var connectionString = configuration.GetConnectionString(ConnectionString.DefaultConnection);
        builder.UseSerilog((context, loggerConfiguration) =>
        {
            loggerConfiguration.WriteTo.Console();

            loggerConfiguration.WriteTo.MSSqlServer(connectionString,
                new MSSqlServerSinkOptions
                {
                    TableName = "Logs",
                    AutoCreateSqlTable = true,
                    SchemaName = "dbo",
                    AutoCreateSqlDatabase = true
                });
        });
        return builder;
    }

    public static IServiceCollection AddIdentity(
        this IServiceCollection services)
    {
        services.AddIdentity<User, Role>(c =>
        {
            c.Password.RequireDigit = true;
            c.Password.RequireLowercase = true;
            c.Password.RequireUppercase = true;
            c.Password.RequireNonAlphanumeric = true;
            c.Password.RequiredLength = 6;
            c.User.RequireUniqueEmail = false;
        })
            .AddEntityFrameworkStores<YallaHaggzDbContext>()
            .AddDefaultTokenProviders();

        return services;
    }

    public static async Task UseDomainDataSeeding(this WebApplication app)
    {
        using var scope = app.Services.CreateScope();

        var services = scope.ServiceProvider;

        var context = services.GetRequiredService<YallaHaggzDbContext>();

        await context.Database.MigrateAsync();

        var seeders = services.GetServices<IDomainDataSeeder>();

        foreach (var seeder in seeders)
        {
            await seeder.SeedEssentialDataAsync();
        }
    }
}