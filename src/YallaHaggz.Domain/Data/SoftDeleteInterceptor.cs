using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using YallaHaggz.Domain.Abstractions;

namespace YallaHaggz.Domain.Data;

public class SoftDeleteInterceptor : SaveChangesInterceptor
{
    public override InterceptionResult<int> SavingChanges(DbContextEventData eventData, InterceptionResult<int> result)
    {
        if (eventData.Context is null)
            return result;

        foreach (var entry in eventData.Context.ChangeTracker.Entries())
        {
            if (entry.Entity is not ISoftDeleteEntity entity || entry.State == EntityState.Detached)
            {
                continue;
            }

            if (entry.State == EntityState.Deleted)
            {
                entity.Delete();

                entry.State = EntityState.Modified;
            }
        }

        return result;
    }
}