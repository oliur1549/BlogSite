  using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Threading.Tasks;
using BlogSite.Framework;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient.Server;

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
            
            return View(post);
        }
    }
}
