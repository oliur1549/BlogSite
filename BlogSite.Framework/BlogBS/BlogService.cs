using BlogSite.Framework.CategoryBS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BlogSite.Framework.BlogBS
{
    public class BlogService : IBlogService, IDisposable
    {
        public IBlogUnitOfWork _blogUnitOfWork { get; set; }
        public BlogService(IBlogUnitOfWork blogUnitOfWork)
        {
            _blogUnitOfWork = blogUnitOfWork;
        }
        public void Createblog(Blog blog)
        {
            var count = _blogUnitOfWork.BlogRepository.GetCount(x => x.Title == blog.Title);
            if (count > 0)
                throw new DuplicationException("Title already exists", nameof(blog.Title));

            _blogUnitOfWork.BlogRepository.Add(blog);
            _blogUnitOfWork.Save();
        }

        public Blog Deleteblog(int id)
        {
            var blog = _blogUnitOfWork.BlogRepository.GetById(id);
            _blogUnitOfWork.BlogRepository.Remove(blog);
            _blogUnitOfWork.Save();
            return blog;
        }

        public void Dispose()
        {
            _blogUnitOfWork?.Dispose();
        }

        public void Editblog(Blog blog)
        {
            var count = _blogUnitOfWork.BlogRepository.GetCount(x => x.Title == blog.Title);
            if (count > 0)
                throw new DuplicationException("Title already exists", nameof(blog.Title));
            var existingblog = _blogUnitOfWork.BlogRepository.GetById(blog.Id);
            existingblog.Id = blog.Id;
            existingblog.Title = blog.Title;
            existingblog.Text = blog.Text;
            existingblog.datetime = blog.datetime;
            existingblog.Image = blog.Image;
            existingblog.CategoryId = blog.CategoryId;
            _blogUnitOfWork.Save();
        }

        public (IList<Blog> records, int total, int totalDisplay) GetBlog(int pageIndex, int pageSize, string searchText, string sortText)
        {
            var result = _blogUnitOfWork.BlogRepository.GetAll();
            return (result, 0, 0);
        }

        public Blog Getblog(int id)
        {
            return _blogUnitOfWork.BlogRepository.GetById(id);
        }
        

        public IEnumerable<Category> GetCategories()
        {
            return _blogUnitOfWork.CategoryRepository.GetAll();
        }

        public Blog GetPost(int id)
        {
            throw new NotImplementedException();
        }
    }
}
