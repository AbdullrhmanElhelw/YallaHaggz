using Microsoft.AspNetCore.Identity;
using YallaHaggz.Domain.Abstractions;

namespace YallaHaggz.Domain.Entites.Users;

public class User : IdentityUser<int>, IAuditableEntity, ISoftDeleteEntity
{
    private string _userName;

    public DateTime CreatedOnUtc { get; private set; }
    public DateTime? ModifiedOnUtc { get; private set; }
    public bool IsDeleted { get; private set; }
    public DateTime? DeletedOnUtc { get; private set; }

    public User(string userName, string? email)
    {
        UserName = userName;
        Email = email;
        CreatedOnUtc = DateTime.UtcNow;
        ModifiedOnUtc = null;
    }

    public override string? Email
    {
        get => base.Email;
        set
        {
            if (!string.IsNullOrEmpty(value) && !value.Contains('@'))
                throw new ArgumentException("Invalid email format.", nameof(value));

            base.Email = value;
        }
    }

    public override string UserName
    {
        get => _userName;
        set
        {
            if (string.IsNullOrWhiteSpace(value))
                throw new ArgumentException("Username cannot be null, empty, or whitespace.", nameof(value));

            _userName = value;
            base.UserName = value;
        }
    }

    public void Update()
    {
        ModifiedOnUtc = DateTime.UtcNow;
    }

    public void Delete()
    {
        IsDeleted = true;
        DeletedOnUtc = DateTime.UtcNow;
    }

    public void Restore()
    {
        IsDeleted = false;
        DeletedOnUtc = null;
    }
}