using Microsoft.AspNetCore.Mvc;
using YallaHaggz.Services.Auth;
using YallaHaggz.Services.Auth.Commands.Login;
using YallaHaggz.Services.Auth.Commands.Register;
using YallaHaggz.Services.Auth.Responses;
using YallaHaggz.WebApi.Contracts;
using YallaHaggz.WebApi.Infrastructure;

namespace YallaHaggz.WebApi.Controllers;

public class AuthController(IAuthService authService) : YallaHaggzController
{
    [HttpPost(ApiRoutes.Auth.Register)]
    public async Task<RegisterResponse> RegisterAsync(
        [FromBody] RegisterUserCommand command,
        CancellationToken cancellationToken)
    {
        var response = await authService.RegisterAsync(command, cancellationToken);
        return response;
    }

    [HttpPost(ApiRoutes.Auth.Login)]
    public async Task<LoginResponse> LoginAsync(
        [FromBody] LoginUserCommand command,
        CancellationToken cancellationToken)
    {
        var response = await authService.LoginAsync(command, cancellationToken);
        return response;
    }
}