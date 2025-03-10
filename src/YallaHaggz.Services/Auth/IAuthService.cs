using YallaHaggz.Services.Auth.Commands.Login;
using YallaHaggz.Services.Auth.Commands.Register;
using YallaHaggz.Services.Auth.Responses;

namespace YallaHaggz.Services.Auth;

public interface IAuthService
{
    Task<LoginResponse> LoginAsync(LoginUserCommand command, CancellationToken cancellation);

    Task<RegisterResponse> RegisterAsync(RegisterUserCommand command, CancellationToken cancellation);
}