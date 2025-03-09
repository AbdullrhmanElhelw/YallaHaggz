using Microsoft.AspNetCore.Identity;

namespace YallaHaggz.Domain.Entites.Roles;

public sealed class Role : IdentityRole<int>
{
    private static readonly string _admin = "Admin";

    public Role(string name)
    {
        Name = name;
        ConcurrencyStamp = Guid.NewGuid().ToString();
        NormalizedName = name.ToUpper();
    }

    public static IReadOnlyCollection<Role> GetDefaultRoles()
    {
        return
        [
            new Role(_admin)
        ];
    }
}