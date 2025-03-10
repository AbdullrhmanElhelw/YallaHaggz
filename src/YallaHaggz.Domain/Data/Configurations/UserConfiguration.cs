using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using YallaHaggz.Domain.Entities.Users;

namespace YallaHaggz.Domain.Data.Configurations;

internal sealed class UserConfiguration : IEntityTypeConfiguration<User>

{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder.ToTable("Users",
            builder => { builder.HasCheckConstraint("CK_User_NationalityId_Length", "LEN(NationalityId) = 14"); });

        builder.HasKey(user => user.Id);
        builder.Property(user => user.FirstName)
            .IsRequired()
            .HasMaxLength(100);

        builder.Property(user => user.LastName)
            .IsRequired()
            .HasMaxLength(100);

        builder.Property(user => user.NationalityId)
            .IsRequired()
            .HasMaxLength(14)
            .IsFixedLength()
            .HasColumnType("CHAR(14)");
    }
}