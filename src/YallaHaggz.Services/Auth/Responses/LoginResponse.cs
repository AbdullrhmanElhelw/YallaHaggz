namespace YallaHaggz.Services.Auth.Responses;

public sealed class LoginResponse
{
    public string Token { get; set; }
    public int UserId { get; set; }
    public string Email { get; set; }
    public string UserName { get; set; }
    public string PhoneNumber { get; set; }
}