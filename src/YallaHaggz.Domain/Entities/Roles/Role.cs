using Microsoft.AspNetCore.Identity;

namespace YallaHaggz.Domain.Entities.Roles;

public sealed class Role : IdentityRole<int>
{
    private static readonly string _admin = "Admin";
    private static readonly string _player = "Player";
    private static readonly string _owner = "Owner";

    public Role(string name)
    {
        Name = name;
        ConcurrencyStamp = Guid.NewGuid().ToString();
        NormalizedName = name.ToUpperInvariant();
    }

    public static IReadOnlyCollection<Role> GetDefaultRoles()
    {
        return
        [
            new Role(_admin),
            new Role(_player),
            new Role(_owner)
        ];
    }
}