using Autofac;
using BlogSite.Framework.BlogBS;
using BlogSite.Framework.CategoryBS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlogSite.Web.Areas.Admin.Models.CategoryModel
{
    public class CategoryBaseModel : AdminBaseModel, IDisposable
    {
        protected readonly ICategoryService _categoryService;

        public CategoryBaseModel(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }
        public CategoryBaseModel()
        {
            _categoryService = Startup.AutofacContainer.Resolve<ICategoryService>();
        }
        public void Dispose()
        {
            _categoryService?.Dispose();
        }
    }
}
