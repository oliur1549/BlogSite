using Autofac;
using BlogSite.Framework.BlogBS;
using BlogSite.Framework.CategoryBS;
using BlogSite.Framework.CommentBS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlogSite.Web.Areas.Admin.Models.CommentsModel
{
    public class CommentsBaseModel : AdminBaseModel, IDisposable
    {
        protected readonly IMainCommentService _mainCommentService;

        public CommentsBaseModel(IMainCommentService mainCommentService)
        {
            _mainCommentService = mainCommentService;
        }
        public CommentsBaseModel()
        {
            _mainCommentService = Startup.AutofacContainer.Resolve<IMainCommentService>();
        }
        public void Dispose()
        {
            _mainCommentService?.Dispose();
        }
    }
}
