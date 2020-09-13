using BlogSite.Data;
using BlogSite.Framework.CommentBS;
using System;
using System.Collections.Generic;
using System.Text;

namespace BlogSite.Framework.BlogBS
{
    public interface ISubCommentRepository : IRepository<SubComment, int, DatabaseContext>
    {
    }
}
