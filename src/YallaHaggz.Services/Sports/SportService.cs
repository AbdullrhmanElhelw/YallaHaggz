using Microsoft.EntityFrameworkCore;
using Volo.Abp.Application.Dtos;
using YallaHaggz.Domain.Data;
using YallaHaggz.Services.Sports.Queries;
using YallaHaggz.Services.Sports.Responses;

namespace YallaHaggz.Services.Sports;

public class SportService(YallaHaggzDbContext dbContext) : ISportService
{
    public async Task<PagedResultDto<SportResponse>> ListAsync(ListSportsQuery query, CancellationToken cancellation)
    {
        var sports = await dbContext.Sports
            .Skip(query.SkipCount)
            .Take(query.MaxResultCount)
            .Select(s => new SportResponse
            {
                Id = s.Id,
                NameAr = s.NameAr,
                NameEn = s.NameEn
            }).ToListAsync(cancellation);

        return new PagedResultDto<SportResponse>(await dbContext.Sports.CountAsync(cancellation), sports);
    }
}