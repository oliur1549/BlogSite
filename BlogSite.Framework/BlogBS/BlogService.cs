using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BlogSite.Framework.BlogBS
{
    public class BlogService : IBlogService, IDisposable
    {
        public void Createblog(Blog blog)
        {
            throw new NotImplementedException();
        }

        public Blog Deleteblog(int id)
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public void Editblog(Blog blog)
        {
            throw new NotImplementedException();
        }

        public (IList<Blog> records, int total, int totalDisplay) GetBlog(int pageIndex, int pageSize, string searchText, string sortText)
        {
            throw new NotImplementedException();
        }

        public Blog Getblog(int id)
        {
            throw new NotImplementedException();
        }
    }
}
