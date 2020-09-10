using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Autofac;
using BlogSite.Framework;
using BlogSite.Web.Areas.Admin.Models;
using BlogSite.Web.Areas.Admin.Models.AdminPanelModel;
using Membership.Contexts;
using Membership.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

namespace BlogSite.Web.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "SuperAdmin")]
    public class AdminPanelController : Controller
    {
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly UserManager<ApplicationUser> _userManager;

        public AdminPanelController(ApplicationDbContext db, UserManager<ApplicationUser> userManager,
            SignInManager<ApplicationUser> signInManager)
        {

            _userManager = userManager;
            _signInManager = signInManager;
        }

        public IActionResult Index()
        {
            var model = new APModel();
            return View(model);
        }
        public IActionResult GetUser()
        {
            var tableModel = new DataTablesAjaxRequestModel(Request);
            var model = Startup.AutofacContainer.Resolve<APModel>();
            var data = model.GetUser(tableModel);
            return Json(data);
        }
        public IActionResult AddAdmin()
        {
            var model = new CreateAPModel();
            return View(model);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult AddAdmin([Bind(
            nameof(CreateAPModel.UserName),
            nameof(CreateAPModel.FullName),
            nameof(CreateAPModel.Email),
            nameof(CreateAPModel.PhoneNumber),
            nameof(CreateAPModel.Status)
            )]
        CreateAPModel model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    model.Create();
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
        public IActionResult EditAdmin(Guid id)
        {
            var model = new EditAPModel();
            model.Load(id);
            return View(model);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult EditAdmin([Bind(
            nameof(EditAPModel.Id), 
            nameof(EditAPModel.UserName), 
            nameof(EditAPModel.FullName), 
            nameof(EditAPModel.Email), 
            nameof(EditAPModel.PhoneNumber),
            nameof(EditAPModel.Status)
            )]
        EditAPModel model)
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
        public IActionResult DeleteAdmin(Guid id)
        {
            if (ModelState.IsValid)
            {
                var model = new APModel();
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
    }
}