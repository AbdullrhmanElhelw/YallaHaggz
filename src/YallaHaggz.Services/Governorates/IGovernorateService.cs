using Volo.Abp.Application.Dtos;
using YallaHaggz.Services.Governorates.Queries;
using YallaHaggz.Services.Governorates.Responses;

namespace YallaHaggz.Services.Governorates;

public interface IGovernorateService
{
    Task<PagedResultDto<GovernorateResponse>> ListGovernoratesAsync(
        ListGovernoratesQuery query,
        CancellationToken cancellationToken);
}