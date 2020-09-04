using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using BlogSite.Data;

namespace BlogSite.Framework.BlogBS
{
    public class BlogRepository : Repository<Blog, int, DatabaseContext>, IBlogRepository
    {
        public BlogRepository(DatabaseContext dbContext)
            : base(dbContext)
        {

        }
    }
}
