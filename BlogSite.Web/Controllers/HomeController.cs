using BlogSite.Framework;
using BlogSite.Framework.BlogBS;
using BlogSite.Framework.CommentBS;
using BlogSite.Web.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using cloudscribe.Pagination.Models;

namespace BlogSite.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private DatabaseContext _context;
        public IBlogUnitOfWork _blogUnitOfWork;
        public HomeController(ILogger<HomeController> logger, DatabaseContext context, IBlogUnitOfWork blogUnitOfWork)
        {
            _logger = logger;
            _context = context;
            _blogUnitOfWork = blogUnitOfWork;
        }


        public IActionResult Index(/*string searchString,*/ int pageNumber=1, int pageSize=3)
        {
            //ViewBag.CurrentFilter = searchString;
            int ExcludeRecords = (pageSize * pageNumber) - pageSize;

            var post = _context.Blogs.OrderByDescending(d => d.datetime)
                                .Skip(ExcludeRecords)
                                .Take(pageSize);

            //var Post = from b in _context.Blogs.Include(m => m.Title).Include(m => m.Text)
            //            select b;

            //var PostCount = Post.Count();

            //if (!String.IsNullOrEmpty(searchString))
            //{
            //    Post = Post.Where(b => b.Title.Contains(searchString));
            //    PostCount = Post.Count();
            //}

            var result = new PagedResult<Blog>
            {
                Data = post.AsNoTracking().ToList(),
                TotalItems = _context.Blogs.Count(),
                PageNumber = pageNumber,
                PageSize = pageSize
            };
            //var post = _context.Blogs.OrderByDescending(d => d.datetime);
            //ViewBag.Post = post;
            var category = _context.Categories.ToList();
            ViewBag.Category = category;
            return View(result);

        }
        public Blog GetPost(int id)
        {
            return  _context.Blogs
                .Include(x => x.MainComments)
                .ThenInclude(xy => xy.subComments)
                .FirstOrDefault(p => p.Id == id);
            
            
        }
        [HttpPost]
        public async Task<IActionResult> Comment(CreateCommentModel model)
        {
            if (!ModelState.IsValid)
                return View("Blog", new { id = model.BlogId });


            var post = GetPost(model.BlogId);
            if (model.MainCommentId>0)
            {

                post.MainComments = post.MainComments ??  new List<MainComment>();

                post.MainComments.Add(new MainComment
                {
                    Message=model.Message,
                    Created=DateTime.Now
                });

                _context.Update(post);
            }
            else
            {
                var comment = new SubComment
                {
                    MainCommentId = model.MainCommentId,
                    Message = model.Message,
                    Created = DateTime.Now
                };
                _context.Add(comment);
            }
            await _context.SaveChangesAsync();
            return View(model);

        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
