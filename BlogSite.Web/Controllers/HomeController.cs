using BlogSite.Framework;
using BlogSite.Framework.BlogBS;
using BlogSite.Web.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

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
            var category = _context.Categories.ToList();
            ViewBag.Category = category;
            return View();

        }
        public IActionResult GetPost(int id)
        {
            var post = _context.Blogs
                .Include(x => x.MainComments)
                .ThenInclude(xy => xy.subComments)
                .FirstOrDefault(p => p.Id == id);
            ViewBag.Post = post;
            return View();
        }
        [HttpPost]
        public IActionResult Comment(CreateCommentModel model)
        {
            if (!ModelState.IsValid)
                return RedirectToAction("Blog", new { id = model.BlogId });
            
            if (model.MainCommentId>0)
            {
                try
                {
                    model.MCCreate();
                    //model.Response = new ResponseModel("Insert Successfull", ResponseType.Success);
                    return RedirectToAction("index");
                }
                //catch (DuplicationException message)
                //{
                //    model.Response = new ResponseModel(message.Message, ResponseType.Failure);
                //}
                catch (Exception ex)
                {
                    ViewBag.Message = "Error";
                    // error logger code
                }

            }
            else
            {
                model.SCCreate();
                //model.Response = new ResponseModel("Insert Successfull", ResponseType.Success);
                return RedirectToAction("index");
            }
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
