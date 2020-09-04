using BlogSite.Data;
using BlogSite.Framework.BlogBS;
using System;
using System.Collections.Generic;
using System.Text;

namespace BlogSite.Framework.CategoryBS
{
    public class Category : IEntity<int>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public IList<Blog> Blogs { get; set; }
    }
}
