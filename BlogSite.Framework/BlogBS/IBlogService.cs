using BlogSite.Framework.CategoryBS;
using System;
using System.Collections.Generic;
using System.Text;

namespace BlogSite.Framework.BlogBS
{
    public interface IBlogService : IDisposable
    {
        (IList<Blog> records, int total, int totalDisplay) GetBlog(int pageIndex,
                                                                    int pageSize,
                                                                    string searchText,
                                                                    string sortText);
        void Createblog(Blog blog);
        void Editblog(Blog blog);
        Blog Getblog(int id);
        Blog Deleteblog(int id);
        IEnumerable<Category> GetCategories();
        Blog GetPost(int id);
    }
}
