using YallaHaggz.Domain.Abstractions;

namespace YallaHaggz.Domain.Entities.Locations;

public sealed class Governorate : Entity
{
    public string NameAr { get; set; }
    public string NameEn { get; set; }

    public ICollection<City> Cities { get; set; } = [];

    public ICollection<Location> Locations { get; set; } = [];
}