using Autofac;
using BlogSite.Framework.CommentBS;

namespace BlogSite.Web.Models
{
    public class CommentBaseModel 
    {
        protected readonly IMainCommentService _commentService;

        public CommentBaseModel(IMainCommentService commentService)
        {
            _commentService = commentService;
        }
        public CommentBaseModel()
        {
            _commentService = Startup.AutofacContainer.Resolve<IMainCommentService>();
        }
        public void Dispose()
        {
            _commentService?.Dispose();
        }
    }
}
