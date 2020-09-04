using BlogSite.Data;
using BlogSite.Framework.BlogBS;
using System;
using System.Collections.Generic;
using System.Text;

namespace BlogSite.Framework
{
    public class BlogUnitOfWork : UnitOfWork, IBlogUnitOfWork
    {
        public IBlogRepository BlogRepository { get; set; }
        public BlogUnitOfWork(DatabaseContext context,
            IBlogRepository blogRepository
            )
            : base(context)
        {
            BlogRepository = blogRepository;
        }
    }
}
