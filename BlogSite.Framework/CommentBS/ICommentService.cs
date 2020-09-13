using BlogSite.Framework.CategoryBS;
using System;
using System.Collections.Generic;
using System.Text;

namespace BlogSite.Framework.CommentBS
{
    public interface ICommentService : IDisposable
    {
        
        void CreateMC(MainComment mainComment);
        IEnumerable<Category> GetCategories();
        void CreateSC(SubComment subComment);
    }
}
