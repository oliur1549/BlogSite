using BlogSite.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace BlogSite.Framework.BlogBS
{
    public interface IBlogRepository : IRepository<Blog, int, DatabaseContext>
    {
    }
}
