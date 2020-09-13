using System;
using System.Collections.Generic;
using System.Text;

namespace BlogSite.Framework.CommentBS
{
    public class MainComment : Comment
    {
        public IList<SubComment> subComments { get; set; }
    }
}
