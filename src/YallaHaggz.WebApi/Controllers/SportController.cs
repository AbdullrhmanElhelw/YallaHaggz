using Microsoft.AspNetCore.Mvc;
using Volo.Abp.Application.Dtos;
using YallaHaggz.Services.Sports;
using YallaHaggz.Services.Sports.Queries;
using YallaHaggz.Services.Sports.Responses;
using YallaHaggz.WebApi.Contracts;
using YallaHaggz.WebApi.Infrastructure;

namespace YallaHaggz.WebApi.Controllers;

public class SportController(ISportService sprotService) : YallaHaggzController
{
    [HttpGet(ApiRoutes.Sports.List)]
    public async Task<PagedResultDto<SportResponse>> ListAsync(
        [FromQuery] ListSportsQuery query,
        CancellationToken cancellationToken)
    {
        var sports = await sprotService.ListAsync(query, cancellationToken);
        return sports;
    }
}