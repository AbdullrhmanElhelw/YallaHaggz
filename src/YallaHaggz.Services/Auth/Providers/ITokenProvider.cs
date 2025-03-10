using System.Security.Claims;

namespace YallaHaggz.Services.Auth.Providers;

public interface ITokenProvider
{
    Task<string> GenerateTokenAsync(List<Claim> claims, CancellationToken cancellationToken);
}