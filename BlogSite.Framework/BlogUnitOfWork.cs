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
        public IMainCommentRepository MainCommentRepository { get ; set ; }
        public ISubCommentRepository SubCommentRepository { get ; set ; }

        public BlogUnitOfWork(DatabaseContext context,
            IBlogRepository blogRepository,
            ICategoryRepository categoryRepository,
            IAboutRepository aboutRepository,
            IMainCommentRepository mainCommentRepository,
            ISubCommentRepository subCommentRepository
            )
            : base(context)
        {
            BlogRepository = blogRepository;
            CategoryRepository = categoryRepository;
            AboutRepository = aboutRepository;
            MainCommentRepository = mainCommentRepository;
            SubCommentRepository = subCommentRepository;
        }
    }
}
