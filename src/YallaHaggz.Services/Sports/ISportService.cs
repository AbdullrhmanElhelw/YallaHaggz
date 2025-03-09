using Volo.Abp.Application.Dtos;
using YallaHaggz.Services.Sports.Queries;
using YallaHaggz.Services.Sports.Responses;

namespace YallaHaggz.Services.Sports;

public interface ISportService
{
    Task<PagedResultDto<SportResponse>> ListAsync(ListSportsQuery query, CancellationToken cancellation);
}