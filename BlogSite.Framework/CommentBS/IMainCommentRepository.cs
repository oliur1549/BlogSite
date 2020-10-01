using BlogSite.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace BlogSite.Framework.CommentBS
{
    public interface IMainCommentRepository : IRepository<MainComment, int , DatabaseContext>
    {
    }
}
