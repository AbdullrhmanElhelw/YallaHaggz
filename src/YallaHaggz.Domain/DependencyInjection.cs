using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using YallaHaggz.Domain.Abstractions;
using YallaHaggz.Domain.Data;
using YallaHaggz.Domain.Data.Seeders;

namespace YallaHaggz.Domain;

public static class DependencyInjection
{
    public static IServiceCollection AddDomain(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddData(configuration);
        services.AddDomainDataSeeders();
        return services;
    }

    public static IServiceCollection AddData(
       this IServiceCollection services,
       IConfiguration configuration)
    {
        var connectionString = configuration.GetConnectionString(ConnectionString.DefaultConnection)
                               ?? throw new InvalidOperationException("Connection string not found.");

        services.AddSingleton(new ConnectionString(connectionString));

        services.AddDbContext<YallaHaggzDbContext>((serviceProvider, options) =>
        {
            var interceptor = serviceProvider.GetRequiredService<SoftDeleteInterceptor>();
            options.UseSqlServer(connectionString)
                   .AddInterceptors(interceptor);
        });

        services.AddScoped<SoftDeleteInterceptor>();

        return services;
    }

    public static IServiceCollection AddDomainDataSeeders(this IServiceCollection services)
    {
        services.AddScoped<IDomainDataSeeder, RoleDataSeeder>();
        services.AddScoped<IDomainDataSeeder, GovernorateDataSeeder>();
        services.AddScoped<IDomainDataSeeder, SportDataSeeder>();
        return services;
    }
}