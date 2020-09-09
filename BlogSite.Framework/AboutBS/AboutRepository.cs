using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Linq.Dynamic.Core;
using BlogSite.Data;

namespace BlogSite.Framework.AboutBS
{
    public class AboutRepository : Repository<About, int, DatabaseContext>, IAboutRepository
    {
        public AboutRepository(DatabaseContext databaseContext) : base(databaseContext)
        {

        }
        public (IList<About> records, int total, int totalDisplay) GetAboutList(
           Expression<Func<About, bool>> filter = null, string orderBy = null,
           Func<IQueryable<About>, IIncludableQueryable<About, object>> include = null,
           int pageIndex = 1, int pageSize = 10, bool isTrackingOff = false)
        {
            IQueryable<About> query = _dbSet;
            var total = query.Count();
            var totalDisplay = query.Count();

            if (filter != null)
            {
                query = query.Where(filter);
                totalDisplay = query.Count();
            }

            if (include != null)
            {
                query = include(query);
            }

            if (orderBy != null)
            {
                var result = query.OrderBy(orderBy).Skip((pageIndex - 1) * pageSize).Take(pageSize);
                if (isTrackingOff)
                    return (result.AsNoTracking().ToList(), total, totalDisplay);
                else
                    return (result.ToList(), total, totalDisplay);
            }
            else
            {
                var result = query.Skip((pageIndex - 1) * pageSize).Take(pageSize);
                if (isTrackingOff)
                    return (result.AsNoTracking().ToList(), total, totalDisplay);
                else
                    return (result.ToList(), total, totalDisplay);
            }
        }
    }
}
