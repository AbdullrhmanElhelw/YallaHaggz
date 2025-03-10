using YallaHaggz.Domain.Abstractions;

namespace YallaHaggz.Domain.Entities.Locations;

public sealed class City : Entity
{
    public string NameAr { get; set; }
    public string NameEn { get; set; }
    public int GovernorateId { get; set; }
    public Governorate Governorate { get; set; }

    public ICollection<Location> Locations { get; set; } = [];
}