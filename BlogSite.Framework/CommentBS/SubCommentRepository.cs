using BlogSite.Data;
using BlogSite.Framework.CommentBS;

namespace BlogSite.Framework.BlogBS
{
    public class SubCommentRepository : Repository<SubComment, int, DatabaseContext>, ISubCommentRepository
    {
        public SubCommentRepository(DatabaseContext dbContext)
            : base(dbContext)
        {

        }
    }
}
