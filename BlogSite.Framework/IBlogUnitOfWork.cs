using BlogSite.Data;
using BlogSite.Framework.AboutBS;
using BlogSite.Framework.BlogBS;
using BlogSite.Framework.CategoryBS;

namespace BlogSite.Framework
{
    public interface IBlogUnitOfWork : IUnitOfWork
    {
        IBlogRepository BlogRepository { get; set; }
        ICategoryRepository CategoryRepository { get; set; }
        IAboutRepository AboutRepository { get; set; }
        IMainCommentRepository MainCommentRepository { get; set; }
        ISubCommentRepository SubCommentRepository { get; set; }
    }
}
