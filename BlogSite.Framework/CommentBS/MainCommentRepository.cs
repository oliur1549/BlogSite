using BlogSite.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace BlogSite.Framework.CommentBS
{
    public class MainCommentRepository : Repository<MainComment, int, DatabaseContext>, IMainCommentRepository
    {
        public MainCommentRepository(DatabaseContext context) : base(context)
        {

        }
    }
}
