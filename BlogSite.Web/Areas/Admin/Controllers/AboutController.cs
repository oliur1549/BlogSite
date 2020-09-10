using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Autofac;
using BlogSite.Framework;
using BlogSite.Web;
using BlogSite.Web.Areas.Admin.Models;
using BlogSite.Web.Areas.Admin.Models.AboutModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

namespace HealthLab.Web.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "SuperAdmin")]
    public class AboutController : Controller
    {
        private readonly IConfiguration _configuration;

        public AboutController(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public IActionResult Index()
        {
            var model = new AboutModel();
            return View(model);
        }
        public IActionResult AddAbout()
        {
            var model = new CreateAboutModel();
            return View(model);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult AddAbout([Bind(nameof(CreateAboutModel.Title), 
            nameof(CreateAboutModel.Description), 
            nameof(CreateAboutModel.imageFile))] 
        CreateAboutModel model)
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
                    // error logger code
                }

            }
            return View(model);
        }
        public IActionResult EditAbout(int id)
        {
            var model = new EditAboutModel();
            model.Load(id);
            return View(model);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult EditAbout([Bind(nameof(EditAboutModel.Id),
            nameof(EditAboutModel.Title),
            nameof(EditAboutModel.Description),
            nameof(EditAboutModel.imageFile))]
        EditAboutModel model)
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
        public IActionResult DeleteAbout(int id)
        {
            if (ModelState.IsValid)
            {
                var model = new AboutModel();
                try
                {
                    var delt = model.Remove(id);
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
        public IActionResult GetAbout()
        {
            var tableModel = new DataTablesAjaxRequestModel(Request);
            var model = Startup.AutofacContainer.Resolve<AboutModel>();
            var data = model.GetAbout(tableModel);
            return Json(data);
        }
    }
}
