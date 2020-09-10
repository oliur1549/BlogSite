using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using BlogSite.Web.Models;
using BlogSite.Framework;
using BlogSite.Framework.BlogBS;
using ReflectionIT.Mvc.Paging;

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

        
        public IActionResult Index()
        {
            var post = _context.Blogs.OrderByDescending(d => d.datetime);
            ViewBag.Post = post;
            //var blog = _context.Blogs.Where(d => d.Id ==d.Id);
            //ViewBag.Blog = blog;
            //var model = await PagingList<Blog>.CreateAsync(post, 10, page); 
            var category = _context.Categories.ToList();
            ViewBag.Category = category;
            return View();
        }

        //public (IList<Blog> records, int total, int totalDisplay) GetBlog(int pageIndex, int pageSize, string searchText, string sortText)
        //{
        //    var result = _blogUnitOfWork.BlogRepository.GetAll();
        //    return (result, 0, 0);
        //}
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
