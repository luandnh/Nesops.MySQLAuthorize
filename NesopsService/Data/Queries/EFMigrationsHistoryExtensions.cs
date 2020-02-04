using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace NesopsService.Data.Queries
{
    public static partial class EFMigrationsHistoryExtensions
    {
        #region Generated Extensions
        public static NesopsService.Data.Entities.EFMigrationsHistory GetByKey(this IQueryable<NesopsService.Data.Entities.EFMigrationsHistory> queryable, string migrationId)
        {
            if (queryable is DbSet<NesopsService.Data.Entities.EFMigrationsHistory> dbSet)
                return dbSet.Find(migrationId);

            return queryable.FirstOrDefault(q => q.MigrationId == migrationId);
        }

        public static ValueTask<NesopsService.Data.Entities.EFMigrationsHistory> GetByKeyAsync(this IQueryable<NesopsService.Data.Entities.EFMigrationsHistory> queryable, string migrationId)
        {
            if (queryable is DbSet<NesopsService.Data.Entities.EFMigrationsHistory> dbSet)
                return dbSet.FindAsync(migrationId);

            var task = queryable.FirstOrDefaultAsync(q => q.MigrationId == migrationId);
            return new ValueTask<NesopsService.Data.Entities.EFMigrationsHistory>(task);
        }

        #endregion

    }
}
