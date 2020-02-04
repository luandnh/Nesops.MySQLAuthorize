using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace NesopsService.Data.Queries
{
    public static partial class ApplicationExtensions
    {
        #region Generated Extensions
        public static NesopsService.Data.Entities.Application GetByKey(this IQueryable<NesopsService.Data.Entities.Application> queryable, int id)
        {
            if (queryable is DbSet<NesopsService.Data.Entities.Application> dbSet)
                return dbSet.Find(id);

            return queryable.FirstOrDefault(q => q.Id == id);
        }

        public static ValueTask<NesopsService.Data.Entities.Application> GetByKeyAsync(this IQueryable<NesopsService.Data.Entities.Application> queryable, int id)
        {
            if (queryable is DbSet<NesopsService.Data.Entities.Application> dbSet)
                return dbSet.FindAsync(id);

            var task = queryable.FirstOrDefaultAsync(q => q.Id == id);
            return new ValueTask<NesopsService.Data.Entities.Application>(task);
        }

        public static IQueryable<NesopsService.Data.Entities.Application> ByOwnerId(this IQueryable<NesopsService.Data.Entities.Application> queryable, int? ownerId)
        {
            return queryable.Where(q => (q.OwnerId == ownerId || (ownerId == null && q.OwnerId == null)));
        }

        #endregion

    }
}
