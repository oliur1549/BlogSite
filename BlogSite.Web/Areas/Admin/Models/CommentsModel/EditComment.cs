using BlogSite.Framework.CommentBS;
using System.ComponentModel.DataAnnotations;


namespace BlogSite.Web.Areas.Admin.Models.CommentsModel
{
    public class EditComment : CommentsBaseModel
    {
        public EditComment(IMainCommentService mainCommentService) : base(mainCommentService) { }
        public EditComment() { }

        public int Id { get; set; }
        [Display(Name = "Message")]
        public string Message { get; set; }
        public bool Status { get; set; }


        public void Edit()
        {

            var comment = new MainComment
            {
                Id = this.Id,
                Message = this.Message,
                Status=this.Status
            };
             
            _mainCommentService.EditComment(comment);
        }

        internal void Load(int id)
        {
            var c = _mainCommentService.GetComment(id);

            if (c != null)
            {
                Id = c.Id;
                Message = c.Message;
                Status = c.Status;

            }
        }
    }
}
