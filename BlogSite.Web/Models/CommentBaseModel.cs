using Autofac;
using BlogSite.Framework.CommentBS;

namespace BlogSite.Web.Models
{
    public class CommentBaseModel 
    {
        protected readonly ICommentService _commentService;

        public CommentBaseModel(ICommentService commentService)
        {
            _commentService = commentService;
        }
        public CommentBaseModel()
        {
            _commentService = Startup.AutofacContainer.Resolve<ICommentService>();
        }
        public void Dispose()
        {
            _commentService?.Dispose();
        }
    }
}
