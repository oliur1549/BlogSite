using System;
using System.Collections.Generic;
using System.Text;

namespace BlogSite.Framework.CommentBS
{
    public class SubComment : Comment
    {
        public int MainCommentId { get; set; }
    }
}
