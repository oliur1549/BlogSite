using Autofac;
using BlogSite.Framework;
using BlogSite.Web.Areas.Admin.Models;
using BlogSite.Web.Areas.Admin.Models.CategoryModel;
using BlogSite.Web.Areas.Admin.Models.CommentsModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;

namespace BlogSite.Web.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class CommentsController : Controller
    {
        private readonly IConfiguration _configuration;
        public CommentsController( IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public IActionResult Index()
        {
            var model = new CommentsModel();
            return View(model);
        }
        public IActionResult edit(int id)
        {
            var model = new EditComment();
            model.Load(id);
            return View(model);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult edit(
            [Bind(nameof(EditComment.Id),
            nameof(EditComment.Message),
            nameof(EditComment.Status)
            )]
            EditComment model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    model.Edit();
                    model.Response = new ResponseModel("update Successfull", ResponseType.Success);
                    return RedirectToAction("Index");
                }
                catch (DuplicationException message)
                {
                    model.Response = new ResponseModel(message.Message, ResponseType.Failure);
                }
                catch (Exception ex)
                {
                    model.Response = new ResponseModel("update Failed.", ResponseType.Failure);
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
                var model = new CommentsModel();
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

        public IActionResult GetComment()
        {
            var tableModel = new DataTablesAjaxRequestModel(Request);
            var model = Startup.AutofacContainer.Resolve<CommentsModel>();
            var data = model.GetComment(tableModel);
            return Json(data);
        }
    }
}