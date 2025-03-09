using Volo.Abp.Application.Dtos;
using YallaHaggz.Services.Cities.Queries;
using YallaHaggz.Services.Cities.Responses;

namespace YallaHaggz.Services.Cities;

public interface ICityService
{
    Task<PagedResultDto<CityResponse>> ListCitiesAsync(int id, ListCitiesQuery query, CancellationToken cancellationToken);
}