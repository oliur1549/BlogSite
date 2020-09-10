using BlogSite.Framework.BlogBS;
using BlogSite.Framework.CategoryBS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlogSite.Web.Areas.Admin.Models.CategoryModel
{
    public class CategoryModel : CategoryBaseModel
    {
        public CategoryModel(ICategoryService categoryService) : base(categoryService) { }
        public CategoryModel() : base() { }

        internal object GetCategory(DataTablesAjaxRequestModel tableModel)
        {
            var data = _categoryService.GetCategory(
                tableModel.PageIndex,
                tableModel.PageSize,
                tableModel.SearchText,
                tableModel.GetSortText(new string[] { "Name" }));

            return new
            {
                recordsTotal = data.total,
                recordsFiltered = data.totalDisplay,
                data = (from record in data.records
                        select new string[]
                        {
                                record.Name,
                                record.Id.ToString()
                        }
                    ).ToArray()

            };
        }

        internal string Delete(int id)
        {
            var deleted = _categoryService.DeleteCategory(id);
            return deleted.Name;
        }
    }
}
