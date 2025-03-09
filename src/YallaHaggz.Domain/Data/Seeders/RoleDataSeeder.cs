using Microsoft.EntityFrameworkCore;
using YallaHaggz.Domain.Abstractions;
using YallaHaggz.Domain.Entites.Roles;

namespace YallaHaggz.Domain.Data.Seeders;

public class RoleDataSeeder(YallaHaggzDbContext dbContext) : IDomainDataSeeder
{
    public async Task SeedEssentialDataAsync()
    {
        var roles = Role.GetDefaultRoles();

        if (!await dbContext.Roles.AnyAsync())
        {
            await dbContext.Roles.AddRangeAsync(roles);
            await dbContext.SaveChangesAsync();
        }
    }
}