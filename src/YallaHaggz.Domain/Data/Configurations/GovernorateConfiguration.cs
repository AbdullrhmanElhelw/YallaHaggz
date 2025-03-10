using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using YallaHaggz.Domain.Entities.Locations;

namespace YallaHaggz.Domain.Data.Configurations;

internal sealed class GovernorateConfiguration : IEntityTypeConfiguration<Governorate>
{
    public void Configure(EntityTypeBuilder<Governorate> builder)
    {
        builder.ToTable("Governorates");

        builder.HasKey(governorate => governorate.Id);

        builder.Property(governorate => governorate.NameAr)
               .IsRequired()
               .HasMaxLength(100);

        builder.Property(governorate => governorate.NameEn)
                .IsRequired()
                .HasMaxLength(100);

        builder.HasIndex(governorate => governorate.NameAr)
               .IsUnique();

        builder.HasIndex(governorate => governorate.NameEn)
                .IsUnique();

        builder.HasMany(governorate => governorate.Cities)
                .WithOne(city => city.Governorate)
                .HasForeignKey(city => city.GovernorateId)
                .OnDelete(DeleteBehavior.Cascade);
    }
}