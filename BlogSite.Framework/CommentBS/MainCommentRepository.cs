using BlogSite.Data;
using BlogSite.Framework.CommentBS;

namespace BlogSite.Framework.BlogBS
{
    public class MainCommentRepository : Repository<MainComment, int, DatabaseContext>, IMainCommentRepository
    {
        public MainCommentRepository(DatabaseContext dbContext)
            : base(dbContext)
        {

        }
    }
}
