using BlogSite.Data;
using BlogSite.Framework.CommentBS;
using System;
using System.Collections.Generic;
using System.Text;

namespace BlogSite.Framework.BlogBS
{
    public interface IMainCommentRepository : IRepository<MainComment, int, DatabaseContext>
    {
    }
}
