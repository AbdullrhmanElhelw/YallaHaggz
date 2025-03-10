using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using YallaHaggz.Domain.Entities.Sports;

namespace YallaHaggz.Domain.Data.Configurations;

internal sealed class SportConfiguration : IEntityTypeConfiguration<Sport>
{
    public void Configure(EntityTypeBuilder<Sport> builder)
    {
        builder.ToTable("Sports");

        builder.HasKey(sport => sport.Id);

        builder.Property(sport => sport.NameAr)
               .IsRequired()
               .HasMaxLength(100);

        builder.Property(sport => sport.NameEn)
               .IsRequired()
               .HasMaxLength(100);

        builder.HasIndex(sport => sport.NameAr)
                .IsUnique();

        builder.HasIndex(sport => sport.NameEn)
                .IsUnique();
    }
}