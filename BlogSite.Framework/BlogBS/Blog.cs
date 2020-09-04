using BlogSite.Data;
using BlogSite.Framework.CategoryBS;
using System;
using System.Collections.Generic;
using System.Text;

namespace BlogSite.Framework.BlogBS
{
    public class Blog : IEntity<int>
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Text { get; set; }
        public DateTime datetime { get; set; }
        public string Image { get; set; }
        public int CategoryId { get; set; }
        public virtual Category Category { get; set; }
    }
}
