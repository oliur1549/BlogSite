using System;
using System.Collections.Generic;
using System.Text;

namespace BlogSite.Framework.CategoryBS
{
    public interface ICategoryService : IDisposable
    {
        (IList<Category> records, int total, int totalDisplay) GetCategory(int pageIndex,
                                                                    int pageSize,
                                                                    string searchText,
                                                                    string sortText);
        void CreateCategory(Category category);
        void EditCategory(Category category);
        Category GetCategory(int id);
        Category DeleteCategory(int id);
    }
}
