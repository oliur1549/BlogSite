using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BlogSite.Framework.CategoryBS
{
    public class CategoryService : ICategoryService, IDisposable
    {
        public IBlogUnitOfWork _blogUnitOfWork { get; set; }
        public CategoryService(IBlogUnitOfWork blogUnitOfWork)
        {
            _blogUnitOfWork = blogUnitOfWork;
        }
        public void CreateCategory(Category category)
        {
            var count = _blogUnitOfWork.CategoryRepository.GetCount(x => x.Name == category.Name);
            if (count > 0)
                throw new DuplicationException("Name already exists", nameof(category.Name));

            _blogUnitOfWork.CategoryRepository.Add(category);
            _blogUnitOfWork.Save();
        }

        public Category DeleteCategory(int id)
        {
            var category = _blogUnitOfWork.CategoryRepository.GetById(id);
            _blogUnitOfWork.CategoryRepository.Remove(category);
            _blogUnitOfWork.Save();
            return category;
        }

        public void Dispose()
        {
            _blogUnitOfWork?.Dispose();
        }

        public void EditCategory(Category category)
        {
            var count = _blogUnitOfWork.CategoryRepository.GetCount(x => x.Name == category.Name);
            if (count > 0)
                throw new DuplicationException("Title already exists", nameof(category.Name));
            var existingblog = _blogUnitOfWork.CategoryRepository.GetById(category.Id);
            existingblog.Id = category.Id;
            existingblog.Name = category.Name;
            _blogUnitOfWork.Save();
        }

        public (IList<Category> records, int total, int totalDisplay) GetCategory(int pageIndex, int pageSize, string searchText, string sortText)
        {
            var result = _blogUnitOfWork.CategoryRepository.GetAll().ToList();
            return (result, 0, 0);
        }

        public Category GetCategory(int id)
        {
            return _blogUnitOfWork.CategoryRepository.GetById(id);
        }
    }
}
