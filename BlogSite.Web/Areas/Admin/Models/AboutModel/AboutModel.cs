using BlogSite.Framework.AboutBS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlogSite.Web.Areas.Admin.Models.AboutModel
{
    public class AboutModel : AboutBaseModel
    {
        public AboutModel(IAboutService aboutService) : base(aboutService) { }
        public AboutModel() : base() { }
        internal object GetAbout(DataTablesAjaxRequestModel tableModel)
        {
            var data = _aboutService.GetAbout(
                tableModel.PageIndex,
                tableModel.PageSize,
                tableModel.SearchText,
                tableModel.GetSortText(new string[] { "Title", "Description", "Image" }));

            return new
            {
                recordsTotal = data.total,
                recordsFiltered = data.totalDisplay,
                data = (from record in data.records
                        select new string[]
                        {
                                record.Title,
                                record.Description,
                                record.Image,
                                record.Id.ToString()
                        }
                    ).ToArray()

            };
        }

        internal string Remove(int id)
        {
            var delete = _aboutService.DeleteSlide(id);
            return delete.Description;
        }
    }
}
