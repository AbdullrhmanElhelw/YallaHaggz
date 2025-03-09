using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using YallaHaggz.Domain.Entites.Locations;
using YallaHaggz.Domain.Entites.Roles;
using YallaHaggz.Domain.Entites.Sports;
using YallaHaggz.Domain.Entites.Users;

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