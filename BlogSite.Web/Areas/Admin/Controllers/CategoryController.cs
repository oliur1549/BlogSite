using Autofac;
using BlogSite.Framework;
using BlogSite.Web.Areas.Admin.Models;
using BlogSite.Web.Areas.Admin.Models.CategoryModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;

namespace BlogSite.Web.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class CategoryController : Controller
    {
        private readonly IConfiguration _configuration;
        public CategoryController( IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public IActionResult Index()
        {
            var model = new CategoryModel();
            return View(model);
        }
        
        public IActionResult AddCategory()
        {
            var model = new CreateCategory();
            return View(model);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult AddCategory(
            [Bind(nameof(CreateCategory.Name))]
            CreateCategory model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    model.Create();
                    model.Response = new ResponseModel("Insert Successfull", ResponseType.Success);
                    return RedirectToAction("Index");
                }
                catch (DuplicationException message)
                {
                    model.Response = new ResponseModel(message.Message, ResponseType.Failure);
                }
                catch (Exception ex)
                {
                    model.Response = new ResponseModel("Insert Failed.", ResponseType.Failure);
                    // error logger code
                }
                
            }
            return View(model);
        }
        [HttpGet]
        public IActionResult EditCtg(int id)
        {
            var model = new EditCategory();
            model.Load(id);
            return View(model);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult EditCtg([Bind(nameof(EditCategory.Id),
            nameof(EditCategory.Name))]
        EditCategory model)
        {
            //model.Edit();
            ////model.Response = new ResponseModel("Insert Successfull", ResponseType.Success);
            //return RedirectToAction("Index");
            if (ModelState.IsValid)
            {
                try
                {
                    model.Edit();
                    model.Response = new ResponseModel("Insert Successfull", ResponseType.Success);
                    return RedirectToAction("Index");
                }
                catch (DuplicationException message)
                {
                    model.Response = new ResponseModel(message.Message, ResponseType.Failure);
                }
                catch (Exception ex)
                {
                    model.Response = new ResponseModel("Insert Failed.", ResponseType.Failure);
                    // error logger code
                }

            }
            return View(model);

        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult delete(int id)
        {
            if (ModelState.IsValid)
            {
                var model = new CategoryModel();
                try
                {
                    var delt = model.Delete(id);
                    model.Response = new ResponseModel($"{delt} Deleted successfull", ResponseType.Success);
                    return RedirectToAction("index");
                }
                catch (Exception ex)
                {
                    model.Response = new ResponseModel("Delete Failed.", ResponseType.Failure);
                }
            }
            return RedirectToAction("index");

            
        }

        public IActionResult GetCategory()
        {
            var tableModel = new DataTablesAjaxRequestModel(Request);
            var model = Startup.AutofacContainer.Resolve<CategoryModel>();
            var data = model.GetCategory(tableModel);
            return Json(data);
        }
    }
}