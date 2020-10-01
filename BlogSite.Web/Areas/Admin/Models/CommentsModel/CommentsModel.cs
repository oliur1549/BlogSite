using BlogSite.Framework.CommentBS;
using System.Linq;

namespace BlogSite.Web.Areas.Admin.Models.CommentsModel
{
    public class CommentsModel : CommentsBaseModel
    {
        public CommentsModel(IMainCommentService mainCommentService) : base(mainCommentService) { }
        public CommentsModel() : base() { }

        internal object GetComment(DataTablesAjaxRequestModel tableModel)
        {
            var data = _mainCommentService.GetComment(
                tableModel.PageIndex,
                tableModel.PageSize,
                tableModel.SearchText,
                tableModel.GetSortText(new string[] { "Message", "Status" }));

            return new
            {
                recordsTotal = data.total,
                recordsFiltered = data.totalDisplay,
                data = (from record in data.records
                        select new string[]
                        {
                                record.Message,
                                record.Status.ToString(),
                                record.Id.ToString()
                        }
                    ).ToArray()

            };
        }

        internal string Delete(int id)
        {
            var deleted = _mainCommentService.DeleteComment(id);
            return deleted.Message;
        }
    }
}
