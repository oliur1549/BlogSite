using Autofac;
using BlogSite.Framework.AdminPanelBS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlogSite.Web.Areas.Admin.Models.AdminPanelModel
{
    public class APBaseModel : AdminBaseModel, IDisposable
    {
        protected readonly IAPService _apService;

        public APBaseModel(IAPService apService)
        {
            _apService = apService;
        }
        public APBaseModel()
        {
            _apService = Startup.AutofacContainer.Resolve<IAPService>();
        }
        public void Dispose()
        {
            _apService?.Dispose();
        }
    }
}
