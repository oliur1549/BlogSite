using System;
using System.Collections.Generic;
using System.Text;

namespace BlogSite.Framework.CommentBS
{
    public class MainCommentService : IMainCommentService
    {
        public IBlogUnitOfWork _blogUnitOfWork { get; set; }
        public MainCommentService(IBlogUnitOfWork blogUnitOfWork)
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

        public (IList<MainComment> records, int total, int totalDisplay) GetComment(int pageIndex, int pageSize, string searchText, string sortText)
        {
            var result = _blogUnitOfWork.MainCommentRepository.GetAll();
            return (result, 0, 0);
        }

        public void EditComment(MainComment comment)
        {
            var prop = _blogUnitOfWork.MainCommentRepository.GetById(comment.Id);
            prop.Id = comment.Id;
            prop.Message = comment.Message;
            prop.Status = comment.Status;
            _blogUnitOfWork.Save();
        }

        public MainComment GetComment(int id)
        {
            return _blogUnitOfWork.MainCommentRepository.GetById(id);
        }

        public MainComment DeleteComment(int id)
        {
            var comm = _blogUnitOfWork.MainCommentRepository.GetById(id);
            _blogUnitOfWork.MainCommentRepository.Remove(comm);
            _blogUnitOfWork.Save();
            return comm;
        }
    }
}
