using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BlogSite.Web.Areas.Admin.Models;
using Membership.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

namespace BlogSite.Web.Areas.Admin.Controllers
{
    
    [Area("Admin")]
    [Authorize(Roles = "SuperAdmin")]
    public class DashboardController : Controller
    {
        private readonly IConfiguration _configuration;
        public DashboardController(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public IActionResult Index()
        {
            var model = new DashBoardModel();
            return View(model);
        }
    }
}
