using Microsoft.EntityFrameworkCore;
using Volo.Abp.Application.Dtos;
using YallaHaggz.Domain.Data;
using YallaHaggz.Services.Cities.Queries;
using YallaHaggz.Services.Cities.Responses;

namespace YallaHaggz.Services.Cities;

public class CityService(
    YallaHaggzDbContext dbContext
    ) : ICityService
{
    public async Task<PagedResultDto<CityResponse>> ListCitiesAsync(int id, ListCitiesQuery query, CancellationToken cancellationToken)
    {
        var cities = await dbContext
            .Cities
            .Where(c => c.GovernorateId == id)
            .OrderBy(c => c.NameEn)
            .ThenBy(c => c.NameAr)
            .Select(c => new CityResponse
            {
                Id = c.Id,
                NameEn = c.NameEn,
                NameAr = c.NameAr
            })
            .ToListAsync(cancellationToken);

        return new PagedResultDto<CityResponse>
        {
            TotalCount = await dbContext.Cities.CountAsync(cancellationToken),
            Items = cities
        };
    }
}