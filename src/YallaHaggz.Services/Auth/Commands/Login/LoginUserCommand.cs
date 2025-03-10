namespace YallaHaggz.Services.Auth.Commands.Login;

public sealed class LoginUserCommand
{
    public string UserNameOrEmail { get; init; }
    public string Password { get; init; }
}