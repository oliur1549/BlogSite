using BlogSite.Framework.BlogBS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlogSite.Web.Areas.Admin.Models.BlogModel
{
    public class BlogModel : BlogBaseModel
    {
        public BlogModel(IBlogService blogService) : base(blogService) { }
        public BlogModel() : base() { }

        internal object GetBlog(DataTablesAjaxRequestModel tableModel)
        {
            var data = _blogService.GetBlog(
                tableModel.PageIndex,
                tableModel.PageSize,
                tableModel.SearchText,
                tableModel.GetSortText(new string[] { "Title", "Text", "datetime", "Image", "Category" }));

            return new
            {
                recordsTotal = data.total,
                recordsFiltered = data.totalDisplay,
                data = (from record in data.records
                        select new string[]
                        {
                                record.Title,
                                record.Text,
                                record.datetime.ToString("dd/mm/yyyy"),
                                record.Image,
                                record.Category.Name,
                                record.Id.ToString()
                        }
                    ).ToArray()

            };
        }

        internal string Delete(int id)
        {
            var deleted = _blogService.Deleteblog(id);
            return deleted.Title;
        }
    }
}
