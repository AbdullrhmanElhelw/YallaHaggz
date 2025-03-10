using YallaHaggz.Domain.Abstractions;

namespace YallaHaggz.Domain.Entities.Locations;

public sealed class Location : Entity
{
    public string Details { get; set; }

    public int GovernorateId { get; set; }
    public Governorate Governorate { get; set; }

    public int CityId { get; set; }
    public City City { get; set; }
}