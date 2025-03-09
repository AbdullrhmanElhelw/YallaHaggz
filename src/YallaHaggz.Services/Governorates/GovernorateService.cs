using Microsoft.EntityFrameworkCore;
using Volo.Abp.Application.Dtos;
using YallaHaggz.Domain.Data;
using YallaHaggz.Services.Governorates.Queries;
using YallaHaggz.Services.Governorates.Responses;

namespace YallaHaggz.Services.Governorates;

public class GovernorateService(YallaHaggzDbContext dbContext) : IGovernorateService
{
    public async Task<PagedResultDto<GovernorateResponse>> ListGovernoratesAsync(
    ListGovernoratesQuery query,
    CancellationToken cancellationToken)
    {
        var governorates = await dbContext
            .Governorates
            .OrderBy(g => g.NameEn)
            .ThenBy(g => g.NameAr)
            .Select(g => new GovernorateResponse
            {
                Id = g.Id,
                NameEn = g.NameEn,
                NameAr = g.NameAr
            })
            .Skip(query.SkipCount)
            .Take(query.MaxResultCount)
            .ToListAsync(cancellationToken);

        return new PagedResultDto<GovernorateResponse>
        {
            TotalCount = await dbContext.Governorates.CountAsync(cancellationToken),
            Items = governorates
        };
    }
}