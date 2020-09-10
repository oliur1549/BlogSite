using BlogSite.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace BlogSite.Framework.CategoryBS
{
    public interface ICategoryRepository : IRepository<Category, int, DatabaseContext>
    {
    }
}
