using System;
using System.Collections.Generic;
using System.Text;

namespace BlogSite.Framework.CommentBS
{
    public interface IMainCommentService : IDisposable
    {
        void CreateMC(MainComment mainComment);
        (IList<MainComment> records, int total, int totalDisplay) GetComment(int pageIndex, int pageSize, string searchText, string sortText);
        void EditComment(MainComment comment);
        MainComment GetComment(int id);
        MainComment DeleteComment(int id);
    }
}
