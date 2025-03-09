using Microsoft.EntityFrameworkCore;
using YallaHaggz.Domain.Abstractions;
using YallaHaggz.Domain.Entites.Sports;

namespace YallaHaggz.Domain.Data.Seeders;

public class SportDataSeeder(YallaHaggzDbContext context) : IDomainDataSeeder
{
    public async Task SeedEssentialDataAsync()
    {
        if (!await context.Sports.AnyAsync())
        {
            await context.Sports.AddRangeAsync(Sports);
            await context.SaveChangesAsync();
        }
    }

    private static IReadOnlyCollection<Sport> Sports =>
        [
        new Sport { NameAr = "كرة القدم", NameEn = "Football" },
        new Sport { NameAr = "كرة السلة", NameEn = "Basketball" },
        new Sport { NameAr = "كرة الطائرة", NameEn = "Volleyball" },
        new Sport { NameAr = "كرة اليد", NameEn = "Handball" },
        new Sport { NameAr = "كرة الطاولة", NameEn = "Table Tennis" },
        new Sport { NameAr = "كرة السلة الشاطئية", NameEn = "Beach Basketball" },
        new Sport { NameAr = "كرة القدم الشاطئية", NameEn = "Beach Football" },
        new Sport { NameAr = "كرة الطائرة الشاطئية", NameEn = "Beach Volleyball" },
        new Sport { NameAr = "كرة اليد الشاطئية", NameEn = "Beach Handball" },
        new Sport { NameAr = "كرة القدم الخماسية", NameEn = "Five-a-side Football" },
        new Sport { NameAr = "كرة القدم النسائية", NameEn="Ladies Football" },
        new Sport {NameAr="الجمباز", NameEn="Gymnastics"},
        new Sport {NameAr="التنس", NameEn="Tennis"},
        ];
}