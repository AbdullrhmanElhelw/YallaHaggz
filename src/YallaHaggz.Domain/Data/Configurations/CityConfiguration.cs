using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using YallaHaggz.Domain.Entites.Locations;

namespace YallaHaggz.Domain.Data.Configurations;

internal sealed class CityConfiguration : IEntityTypeConfiguration<City>
{
    public void Configure(EntityTypeBuilder<City> builder)
    {
        builder.ToTable("Cities");

        builder.HasKey(city => city.Id);

        builder.Property(city => city.NameAr)
               .IsRequired()
               .HasMaxLength(100);

        builder.Property(city => city.NameEn)
                .IsRequired()
                .HasMaxLength(100);

        builder.HasIndex(city => city.NameAr)
               .IsUnique();

        builder.HasIndex(city => city.NameEn)
                .IsUnique();
    }
}