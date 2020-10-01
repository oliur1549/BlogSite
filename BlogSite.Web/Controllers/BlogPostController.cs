using System.Linq;
using System.Linq.Dynamic.Core;
using BlogSite.Framework;
using BlogSite.Web.Models;
using Microsoft.AspNetCore.Mvc;

namespace BlogSite.Web.Controllers
{
    public class BlogPostController : Controller
    {
        private DatabaseContext _context;

        public BlogPostController(DatabaseContext context)
        {
            _context = context;
        }
        
        public IActionResult Index(int id)
        {
            var post = _context.Blogs.Find(id);
            var comment = _context.MainComments.Where(c => c.BlogId == id && c.Status==true);
            ViewBag.Comment = comment;
            return View(post);
        }
        [HttpPost]
        public IActionResult Comments(CreateCommentModel model)
        {
            
            model.MCCreate();
            return RedirectToAction("index", new { id = model.BlogsId });
        }
    }
}
