using Autofac;
using BlogSite.Framework.BlogBS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlogSite.Web.Areas.Admin.Models.BlogModel
{
    public class BlogBaseModel : AdminBaseModel, IDisposable
    {
        protected readonly IBlogService _blogService;

        public BlogBaseModel(IBlogService blogService)
        {
            _blogService = blogService;
        }
        public BlogBaseModel()
        {
            _blogService = Startup.AutofacContainer.Resolve<IBlogService>();
        }
        public void Dispose()
        {
            _blogService?.Dispose();
        }
    }
}
