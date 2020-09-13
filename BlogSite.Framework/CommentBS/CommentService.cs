using BlogSite.Framework.CategoryBS;
using System;
using System.Collections.Generic;

namespace BlogSite.Framework.CommentBS
{
    public class CommentService : ICommentService, IDisposable
    {
        public IBlogUnitOfWork _blogUnitOfWork { get; set; }
        public CommentService(IBlogUnitOfWork blogUnitOfWork)
        {
            _blogUnitOfWork = blogUnitOfWork;
        }

        public void CreateMC(MainComment mainComment)
        {
            _blogUnitOfWork.MainCommentRepository.Add(mainComment);
            _blogUnitOfWork.Save();
        }
        public void Dispose()
        {
            _blogUnitOfWork?.Dispose();
        }
        public IEnumerable<Category> GetCategories()
        {
            throw new NotImplementedException();
        }

        public void CreateSC(SubComment subComment)
        {
            _blogUnitOfWork.SubCommentRepository.Add(subComment);
            _blogUnitOfWork.Save();
        }

        
    }
}
