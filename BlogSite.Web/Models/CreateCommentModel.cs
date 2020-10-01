using BlogSite.Framework.CommentBS;
using System;

namespace BlogSite.Web.Models
{
    public class CreateCommentModel : CommentBaseModel
    {
        public int BlogsId { get; set; }
        public string Message { get; set; }
        public DateTime Created { get; set; }
        

        public CreateCommentModel (IMainCommentService mainComment) : base(mainComment) { }
        public CreateCommentModel () : base() { }

        public void MCCreate()
        {

            var mainComment = new MainComment
            {
                Message = this.Message,
                Created = this.Created,
                BlogId=this.BlogsId
            };

            _commentService.CreateMC(mainComment);
        }



    }

}
