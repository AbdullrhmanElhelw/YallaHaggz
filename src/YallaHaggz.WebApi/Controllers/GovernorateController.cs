using Microsoft.AspNetCore.Mvc;
using Volo.Abp.Application.Dtos;
using YallaHaggz.Services.Governorates;
using YallaHaggz.Services.Governorates.Queries;
using YallaHaggz.Services.Governorates.Responses;
using YallaHaggz.WebApi.Contracts;
using YallaHaggz.WebApi.Infrastructure;

namespace YallaHaggz.WebApi.Controllers;

public class GovernorateController(IGovernorateService governorateService) : YallaHaggzController
{
    [HttpGet(ApiRoutes.Governorates.List)]
    public async Task<PagedResultDto<GovernorateResponse>> ListGovernoratesAsync(
        [FromQuery] ListGovernoratesQuery query,
        CancellationToken cancellationToken)
    {
        var governorates = await governorateService.ListGovernoratesAsync(query, cancellationToken);
        return governorates;
    }
}