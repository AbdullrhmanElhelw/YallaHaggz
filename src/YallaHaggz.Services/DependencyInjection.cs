using Microsoft.Extensions.DependencyInjection;
using YallaHaggz.Services.Cities;
using YallaHaggz.Services.Governorates;
using YallaHaggz.Services.Sports;

namespace YallaHaggz.Services;

public static class DependencyInjection
{
    public static IServiceCollection AddServices(this IServiceCollection services)
    {
        services.AddScoped<IGovernorateService, GovernorateService>();
        services.AddScoped<ICityService, CityService>();
        services.AddScoped<ISportService, SportService>();
        return services;
    }
}