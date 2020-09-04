using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BlogSite.Framework.CategoryBS
{
    public class CategoryService : ICategoryService, IDisposable
    {
        public void CreateCategory(Category category)
        {
            throw new NotImplementedException();
        }

        public Category DeleteCategory(int id)
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public void EditCategory(Category category)
        {
            throw new NotImplementedException();
        }

        public (IList<Category> records, int total, int totalDisplay) GetCategory(int pageIndex, int pageSize, string searchText, string sortText)
        {
            throw new NotImplementedException();
        }

        public Category GetCategory(int id)
        {
            throw new NotImplementedException();
        }
    }
}
