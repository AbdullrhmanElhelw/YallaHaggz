using FluentValidation;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;
using YallaHaggz.Domain.Data;
using YallaHaggz.Domain.Entities.Users;
using YallaHaggz.Services.Auth.Commands.Login;
using YallaHaggz.Services.Auth.Commands.Register;
using YallaHaggz.Services.Auth.Providers;
using YallaHaggz.Services.Auth.Responses;

namespace YallaHaggz.Services.Auth;

public class AuthService(
    UserManager<User> userManager,
    YallaHaggzDbContext dbContext,
    IValidator<RegisterUserCommand> validator,
    IValidator<LoginUserCommand> loginValidator,
    ITokenProvider tokenProvider
    ) : IAuthService
{
    public async Task<LoginResponse> LoginAsync(LoginUserCommand command, CancellationToken cancellation)
    {
        var validationResult = await loginValidator.ValidateAsync(command, cancellation);
        if (!validationResult.IsValid)
            throw new ValidationException(validationResult.Errors);

        var user = await userManager.FindByNameAsync(command.UserNameOrEmail)
                   ?? await userManager.FindByEmailAsync(command.UserNameOrEmail)
                   ?? throw new InvalidOperationException("User not found.");

        if (!await userManager.CheckPasswordAsync(user, command.Password))
            throw new InvalidOperationException("Invalid password.");

        var claims = new List<Claim>
    {
        new(ClaimTypes.Name, user.UserName),
        new(ClaimTypes.NameIdentifier, user.Id.ToString()),
        new(ClaimTypes.Email, user.Email ?? string.Empty),
        new(ClaimTypes.MobilePhone, user.PhoneNumber ?? string.Empty)
    };

        var token = await tokenProvider.GenerateTokenAsync(claims, cancellation).ConfigureAwait(false);

        return new LoginResponse
        {
            UserName = user.UserName,
            Email = user.Email ?? string.Empty,
            PhoneNumber = user.PhoneNumber ?? string.Empty,
            Token = token
        };
    }

    public async Task<RegisterResponse> RegisterAsync(RegisterUserCommand command, CancellationToken cancellation)
    {
        var validationResult = await validator.ValidateAsync(command, cancellation);
        if (!validationResult.IsValid)
            throw new ValidationException(validationResult.Errors);

        var userIsExists = await dbContext.Users.AnyAsync(u =>
                                    u.Email == command.Email ||
                                    u.UserName == command.UserName ||
                                    u.PhoneNumber == command.PhoneNumber ||
                                    u.NationalityId == command.NationalityId, cancellation);

        if (userIsExists)
        {
            throw new InvalidOperationException("User already exists.");
        }

        var user = User.Create(
            command.FirstName,
            command.LastName,
            command.UserName,
            command.Email,
            command.PhoneNumber,
            command.NationalityId);

        using var transaction = await dbContext.Database.BeginTransactionAsync(cancellation);

        try
        {
            var result = await userManager.CreateAsync(user, command.Password);
            if (!result.Succeeded)
            {
                throw new InvalidOperationException("Failed to create user.");
            }

            var roleResult = await userManager.AddToRoleAsync(user, command.Role);

            if (!roleResult.Succeeded)
            {
                throw new InvalidOperationException("Failed to assign role to user.");
            }

            await dbContext.SaveChangesAsync(cancellation);
            await transaction.CommitAsync(cancellation);
            return new RegisterResponse
            {
                Id = user.Id,
                UserName = user.UserName,
                Email = user.Email,
                PhoneNumber = user.PhoneNumber,
                NationalityId = user.NationalityId,
                FirstName = user.FirstName,
                LastName = user.LastName,
                Role = command.Role
            };
        }
        catch (Exception)
        {
            await transaction.RollbackAsync(cancellation);
            throw;
        }
    }
}