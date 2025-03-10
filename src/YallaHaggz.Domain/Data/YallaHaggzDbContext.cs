using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using YallaHaggz.Domain.Entities.Locations;
using YallaHaggz.Domain.Entities.Roles;
using YallaHaggz.Domain.Entities.Sports;
using YallaHaggz.Domain.Entities.Users;

namespace YallaHaggz.Domain.Data;

public class YallaHaggzDbContext(DbContextOptions<YallaHaggzDbContext> options) : IdentityDbContext<User, Role, int>(options)
{
    public DbSet<City> Cities { get; set; }

    public DbSet<Sport> Sports { get; set; }

    public DbSet<Governorate> Governorates { get; set; }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
        builder.ApplyConfigurationsFromAssembly(typeof(YallaHaggzDbContext).Assembly);
    }
}
