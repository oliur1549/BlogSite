using Autofac;
using BlogSite.Framework.AboutBS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlogSite.Web.Areas.Admin.Models.AboutModel
{
    public class AboutBaseModel : AdminBaseModel, IDisposable
    {
        protected readonly IAboutService _aboutService;

        public AboutBaseModel(IAboutService aboutService)
        {
            _aboutService = aboutService;
        }

        public AboutBaseModel()
        {
            _aboutService = Startup.AutofacContainer.Resolve<IAboutService>();
        }

        public void Dispose()
        {
            _aboutService?.Dispose();
        }
    }
}
