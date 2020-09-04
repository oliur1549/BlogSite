using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using BlogSite.Data;

namespace BlogSite.Framework.CategoryBS
{
    public class CategoryRepository : Repository<Category, int, DatabaseContext>, ICategoryRepository
    {
        public CategoryRepository(DatabaseContext dbContext)
            : base(dbContext)
        {

        }
    }
}
