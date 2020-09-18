using BlogSite.Framework.CommentBS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlogSite.Web.Models
{
    public class CreateCommentModel
    {
        public int BlogId { get; set; }
        public int MainCommentId { get; set; }
        public string Message { get; set; }
        public DateTime Created { get; set; } = DateTime.Now;


        //public void MCCreate()
        //{

        //    var mainComment = new MainComment
        //    {
        //        Message = this.Message,
        //        Created=this.Created,

        //    };

        //    _commentService.CreateMC(mainComment);
        //}
        //public void SCCreate()
        //{

        //    var subComment = new SubComment
        //    {
        //        MainCommentId=this.MainCommentId,
        //        Message = this.Message,
        //        Created = this.Created,

        //    };

        //    _commentService.CreateSC(subComment);
        //}



    }

}
