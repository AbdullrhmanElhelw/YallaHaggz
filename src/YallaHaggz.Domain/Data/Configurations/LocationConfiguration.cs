using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using YallaHaggz.Domain.Entites.Locations;

namespace YallaHaggz.Domain.Data.Configurations;

internal sealed class LocationConfiguration : IEntityTypeConfiguration<Location>
{
    public void Configure(EntityTypeBuilder<Location> builder)
    {
        builder.ToTable("Locations");

        builder.HasKey(location => location.Id);

        builder.Property(location => location.Details)
               .IsRequired()
               .HasMaxLength(500);

        builder.HasOne(location => location.Governorate)
                .WithMany(governorate => governorate.Locations)
                .HasForeignKey(location => location.GovernorateId)
                .OnDelete(DeleteBehavior.Cascade);

        builder.HasOne(location => location.City)
                .WithMany(city => city.Locations)
                .HasForeignKey(location => location.CityId)
                .OnDelete(DeleteBehavior.Cascade);
    }
}