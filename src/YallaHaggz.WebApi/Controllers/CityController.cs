using Microsoft.AspNetCore.Mvc;
using Volo.Abp.Application.Dtos;
using YallaHaggz.Services.Cities;
using YallaHaggz.Services.Cities.Queries;
using YallaHaggz.Services.Cities.Responses;
using YallaHaggz.WebApi.Contracts;
using YallaHaggz.WebApi.Infrastructure;

namespace YallaHaggz.WebApi.Controllers;

public class CityController(ICityService cityService) : YallaHaggzController
{
    [HttpGet(ApiRoutes.Cities.List)]
    public async Task<PagedResultDto<CityResponse>> ListCitiesAsync(
        int id,
        [FromQuery] ListCitiesQuery query,
        CancellationToken cancellationToken)
    {
        var cities = await cityService.ListCitiesAsync(id, query, cancellationToken);
        return cities;
    }
}
