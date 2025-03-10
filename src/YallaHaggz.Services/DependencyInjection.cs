using FluentValidation;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using YallaHaggz.Services.Auth;
using YallaHaggz.Services.Auth.Providers;
using YallaHaggz.Services.Auth.Settings;
using YallaHaggz.Services.Cities;
using YallaHaggz.Services.Governorates;
using YallaHaggz.Services.Sports;

namespace YallaHaggz.Services;

public static class DependencyInjection
{
    public static IServiceCollection AddServices(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddScoped<IGovernorateService, GovernorateService>();
        services.AddScoped<ICityService, CityService>();
        services.AddScoped<ISportService, SportService>();
        services.AddScoped<IAuthService, AuthService>();
        services.AddScoped<ITokenProvider, TokenProvider>();

        services.AddValidatorsFromAssemblies([typeof(DependencyInjection).Assembly]);

        services.AddJwt(configuration);
        services.AddAuthenticationSchema(configuration);
        return services;
    }

    public static IServiceCollection AddJwt(
       this IServiceCollection services,
       IConfiguration configuration)
    {
        var jwtSettings = configuration.GetSection(JwtSettings.SectionName)
                         ?? throw new InvalidOperationException("JwtSettings not found.");

        services.Configure<JwtSettings>(jwtSettings);
        services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
            .AddJwtBearer(options =>
            {
                options.RequireHttpsMetadata = false;
                options.SaveToken = true;
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = true,
                    ValidIssuer = jwtSettings[nameof(JwtSettings.Issuer)],
                    ValidateAudience = true,
                    ValidAudience = jwtSettings[nameof(JwtSettings.Audience)],
                    ValidateLifetime = true,
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(jwtSettings[nameof(JwtSettings.Secret)])),
                    ValidateIssuerSigningKey = true
                };
            });
        return services;
    }

    public static IServiceCollection AddAuthenticationSchema(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddAuthentication(op =>
        {
            op.DefaultAuthenticateScheme = "Default";
            op.DefaultChallengeScheme = "Default";
        })
            .AddJwtBearer("Default", op =>
            {
                var settings = configuration.GetSection(JwtSettings.SectionName).Get<JwtSettings>();
                var readKey = Encoding.ASCII.GetBytes(settings.Secret);
                var key = new SymmetricSecurityKey(readKey);
                op.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = false,
                    ValidateAudience = false,
                    ValidateLifetime = false,
                    ValidateIssuerSigningKey = false,
                    ValidIssuer = settings.Issuer,
                    ValidAudience = settings.Audience,
                    IssuerSigningKey = key
                };
            });

        return services;
    }
}