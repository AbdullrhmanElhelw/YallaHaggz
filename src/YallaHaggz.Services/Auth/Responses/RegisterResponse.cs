namespace YallaHaggz.Services.Auth.Responses;

public sealed class RegisterResponse
{
    public int Id { get; init; }

    public string UserName { get; init; }
    public string FirstName { get; init; }
    public string LastName { get; init; }
    public string Email { get; init; }
    public string Role { get; init; }
    public string NationalityId { get; init; }
    public string PhoneNumber { get; init; }
}