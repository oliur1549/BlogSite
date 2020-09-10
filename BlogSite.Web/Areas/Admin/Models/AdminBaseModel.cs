using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using Autofac;
using BlogSite.Web;
using BlogSite.Framework;

namespace BlogSite.Web.Areas.Admin.Models
{
    public abstract class AdminBaseModel
    {
        public MenuModel MenuModel { get; set; }
        public ResponseModel Response
        {
            get
            {
                if (_httpContextAccessor.HttpContext.Session.IsAvailable &&
                    _httpContextAccessor.HttpContext.Session.Keys.Contains(nameof(Response)))
                {
                    var response = _httpContextAccessor.HttpContext.Session.Get<ResponseModel>(nameof(Response));
                    _httpContextAccessor.HttpContext.Session.Remove(nameof(Response));

                    return response;
                }
                else
                    return null;
            }
            set
            {
                _httpContextAccessor.HttpContext.Session.Set(nameof(Response), value);
            }
        }

        protected IHttpContextAccessor _httpContextAccessor;
        public AdminBaseModel(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
            SetupMenu();
        }

        public AdminBaseModel()
        {
            _httpContextAccessor = Startup.AutofacContainer.Resolve<IHttpContextAccessor>();
            SetupMenu();
        }
        private void SetupMenu()
        {
            MenuModel = new MenuModel
            {
                MenuItems = new List<MenuItem>
                {
                    {
                        new MenuItem
                        {
                            Title = "Admin Settings",
                            Childs = new List<MenuChildItem>
                            {
                                new MenuChildItem{ Title = "Admin", Url = "/Admin/AdminPanel/Index" },
                                new MenuChildItem{ Title = "Create Admin", Url = "/Admin/AdminPanel/AddAdmin" },
                            }
                        }
                    },
                    {
                        new MenuItem
                        {
                            Title = "Category",
                            Childs = new List<MenuChildItem>
                            {
                                new MenuChildItem{ Title = "View", Url = "/Admin/Category/Index" },
                                new MenuChildItem{ Title = "Create", Url = "/Admin/Category/AddCategory" },
                            }
                        }
                    },
                    {
                        new MenuItem
                        {
                            Title = "Blog",
                            Childs = new List<MenuChildItem>
                            {
                                new MenuChildItem{ Title = "View", Url = "/Admin/Blog/Index" },
                                new MenuChildItem{ Title = "Create", Url = "/Admin/Blog/addblog" },
                            }
                        }
                    },
                    {
                        new MenuItem
                        {
                            Title = "About",
                            Childs = new List<MenuChildItem>
                            {
                                new MenuChildItem{ Title = "View", Url = "/Admin/About/Index" },
                                new MenuChildItem{ Title = "Create", Url = "/Admin/About/addabout" },
                            }
                        }
                    }
                }
            };
        }


    }
}
