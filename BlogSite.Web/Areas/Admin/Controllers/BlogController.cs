using System;
using System.Collections.Generic;
using Autofac;
using BlogSite.Framework;
using BlogSite.Web.Areas.Admin.Models;
using BlogSite.Web.Areas.Admin.Models.BlogModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

namespace BlogSite.Web.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "SuperAdmin")]
    public class BlogController : Controller
    {
        private readonly IConfiguration _configuration;

        public BlogController(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public IActionResult Index()
        {
            var model = new BlogModel();
            return View(model);
        }
        public IActionResult AddBlog()
        {
            var model = new CreateBlog();
            return View(model);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult AddBlog([Bind(nameof(CreateBlog.Title), 
            nameof(CreateBlog.Text),
            nameof(CreateBlog.datetime),
            nameof(CreateBlog.imageFile),
            nameof(CreateBlog.CategoryId)
            )]
        CreateBlog model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    model.Create();
                    model.Response = new ResponseModel("Insert Successfull", ResponseType.Success);
                    return RedirectToAction("index");
                }
                catch (DuplicationException message)
                {
                    model.Response = new ResponseModel(message.Message, ResponseType.Failure);
                }
                catch (Exception ex)
                {
                    model.Response = new ResponseModel("Insert Failed.", ResponseType.Failure);
                    //logger.Error(ex, "Something bad happened");
                    // error logger code
                }

            }
            return View(model);
        }
        public IActionResult editblog(int id)
        {
            var model = new EditBlog();
            model.Load(id);
            return View(model);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult editblog([Bind(
            nameof(EditBlog.Id),
            nameof(EditBlog.Title),
            nameof(EditBlog.Text),
            nameof(EditBlog.datetime),
            nameof(EditBlog.imageFile),
            nameof(EditBlog.CategoryId)
            )]
        EditBlog model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    model.Edit();
                    model.Response = new ResponseModel("Update Successfull", ResponseType.Success);
                    return RedirectToAction("index");
                }
                catch (DuplicationException message)
                {
                    model.Response = new ResponseModel(message.Message, ResponseType.Failure);
                }
                catch (Exception ex)
                {
                    model.Response = new ResponseModel("Update Failed.", ResponseType.Failure);
                    // error logger code
                }

            }
            return View(model);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteBlog(int id)
        {
            if (ModelState.IsValid)
            {
                var model = new BlogModel();
                try
                {
                    var delt = model.Delete(id);
                    model.Response = new ResponseModel($"{delt} Deleted successfull", ResponseType.Success);
                    return RedirectToAction("index");
                }
                catch (Exception ex)
                {
                    model.Response = new ResponseModel("Insert Failed.", ResponseType.Failure);
                }
            }
            return RedirectToAction("index");
        }
        public IActionResult GetBlog()
        {
            var tableModel = new DataTablesAjaxRequestModel(Request);
            var model = Startup.AutofacContainer.Resolve<BlogModel>();
            var data = model.GetBlog(tableModel);
            return Json(data);
        }
    }
}
