using BlogSite.Data;
using Microsoft.EntityFrameworkCore.Query;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace BlogSite.Framework.AboutBS
{
    public interface IAboutRepository : IRepository<About, int, DatabaseContext>
    {
        (IList<About> records, int total, int totalDisplay) GetAboutList(
            Expression<Func<About, bool>> filter = null,
            string orderBy = null,
            Func<IQueryable<About>, IIncludableQueryable<About, object>> include = null,
            int pageIndex = 1, int pageSize = 10, bool isTrackingOff = false);
    }
}
