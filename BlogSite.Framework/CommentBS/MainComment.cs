using BlogSite.Data;
using BlogSite.Framework.BlogBS;
using System;
using System.Collections.Generic;
using System.Text;

namespace BlogSite.Framework.CommentBS
{
    public class MainComment : IEntity<int>
    {
        public int Id { get; set; }
        public string Message { get; set; }
        public DateTime Created { get; set; }
        public bool Status { get; set; }
        public int BlogId { get; set; }
        public Blog Blog { get; set; }
    }
}
