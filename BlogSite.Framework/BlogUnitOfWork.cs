using BlogSite.Data;
using BlogSite.Framework.AboutBS;
using BlogSite.Framework.BlogBS;
using BlogSite.Framework.CategoryBS;
using System;
using System.Collections.Generic;
using System.Text;

namespace BlogSite.Framework
{
    public class BlogUnitOfWork : UnitOfWork, IBlogUnitOfWork
    {
        public IBlogRepository BlogRepository { get; set; }
        public ICategoryRepository CategoryRepository { get ; set; }
        public IAboutRepository AboutRepository { get; set; }

        public BlogUnitOfWork(DatabaseContext context,
            IBlogRepository blogRepository,
            ICategoryRepository categoryRepository,
            IAboutRepository aboutRepository
            )
            : base(context)
        {
            BlogRepository = blogRepository;
            CategoryRepository = categoryRepository;
            AboutRepository = aboutRepository;
        }
    }
}
