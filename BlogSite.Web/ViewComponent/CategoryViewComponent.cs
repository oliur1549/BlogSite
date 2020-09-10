using BlogSite.Framework;
using BlogSite.Framework.CategoryBS;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlogSite.Web.CategoryViewComponent
{
    [ViewComponent(Name = "CategoryInfo")]
    public class CategoryViewComponent : ViewComponent
    {
        private DatabaseContext db;
        public CategoryViewComponent(DatabaseContext _db)
        {
            db = _db;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            List<Category> CategoryInfo = db.Categories.ToList();
            return View("index",CategoryInfo);
        }
    }
}
