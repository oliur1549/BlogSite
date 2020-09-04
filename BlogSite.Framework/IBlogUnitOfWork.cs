using BlogSite.Data;
using BlogSite.Framework.BlogBS;
using System;
using System.Collections.Generic;
using System.Text;

namespace BlogSite.Framework
{
    public interface IBlogUnitOfWork : IUnitOfWork
    {
        IBlogRepository BlogRepository { get; set; }
    }
}
