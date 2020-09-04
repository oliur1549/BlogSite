using BlogSite.Framework.AdminPanelBS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlogSite.Web.Areas.Admin.Models.AdminPanelModel
{
    public class APModel : APBaseModel
    {
        public APModel(IAPService apService) : base(apService) { }
        public APModel() : base() { }

        internal object GetUser(DataTablesAjaxRequestModel tableModel)
        {
            var data = _apService.GetUser(
                tableModel.PageIndex,
                tableModel.PageSize,
                tableModel.SearchText,
                tableModel.GetSortText(new string[] { "UserName", "FullName", "Email", "PhoneNumber", "Status" }));

            return new
            {
                recordsTotal = data.total,
                recordsFiltered = data.totalDisplay,
                data = (from record in data.records
                        select new string[]
                        {
                                record.UserName,
                                record.FullName,
                                record.Email,
                                record.PhoneNumber,
                                record.Status.ToString(),
                                record.Id.ToString()
                        }
                    ).ToArray()

            };
        }

        internal string Delete(Guid id)
        {
            var deleted = _apService.DeleteUser(id);
            return deleted.FullName;
        }
    }
}
