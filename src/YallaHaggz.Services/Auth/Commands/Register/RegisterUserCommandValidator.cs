using FluentValidation;
using System.Text.RegularExpressions;
using YallaHaggz.Domain.Entities.Roles;

namespace YallaHaggz.Services.Auth.Commands.Register;

public sealed class RegisterUserCommandValidator : AbstractValidator<RegisterUserCommand>
{
    public RegisterUserCommandValidator()
    {
        RuleFor(x => x.FirstName)
             .NotEmpty().WithMessage("First Name is required")
             .MaximumLength(100).WithMessage("First Name cannot be longer than 100 characters");

        RuleFor(x => x.LastName)
            .NotEmpty().WithMessage("Last Name is required")
            .MaximumLength(100).WithMessage("Last Name cannot be longer than 100 characters");

        RuleFor(x => x.UserName)
            .Matches("^[a-zA-Z0-9]*$").WithMessage("Username cannot contain special characters or spaces")
            .NotEmpty().WithMessage("Username is required")
            .MaximumLength(20).WithMessage("Username cannot be longer than 20 characters");

        RuleFor(x => x.Email)
            .NotEmpty().WithMessage("Email is required")
            .EmailAddress().WithMessage("Email is not a valid email address");

        RuleFor(x => x.Password)
            .NotEmpty().WithMessage("Password is required")
            .MinimumLength(6).WithMessage("Password must be at least 6 characters")
            .Matches(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[^\da-zA-Z]).{8,}$")
            .WithMessage("Password must contain at least one uppercase letter, one lowercase letter, one number and one special character");

        RuleFor(x => x.ConfirmPassword)
            .Equal(x => x.Password).WithMessage("Passwords do not match");

        RuleFor(x => x.Role)
            .Matches($"^({string.Join("|", GetRoles)})$", RegexOptions.IgnoreCase).WithMessage("Role is not valid")
            .NotEmpty().WithMessage("Role is required");
    }

    private static IReadOnlyCollection<string> GetRoles => [.. Role.GetDefaultRoles().Select(x => x.Name)];
}