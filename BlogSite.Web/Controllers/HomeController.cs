using BlogSite.Framework;
using BlogSite.Framework.BlogBS;
using BlogSite.Web.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System.Diagnostics;
using System.Linq;
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


        public IActionResult Index( int pageNumber=1, int pageSize=3 )
        {
            int ExcludeRecords = (pageSize * pageNumber) - pageSize;

            var post = _context.Blogs.OrderByDescending(d => d.datetime)
                                .Skip(ExcludeRecords)
                                .Take(pageSize);

            var result = new PagedResult<Blog>
            {
                Data = post.AsNoTracking().ToList(),
                TotalItems = _context.Blogs.Count(),
                PageNumber = pageNumber,
                PageSize = pageSize
            };
            
            var category = _context.Categories.ToList();
            ViewBag.Category = category;
            return View(result);

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
