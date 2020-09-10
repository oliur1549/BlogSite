using Autofac;
using BlogSite.Web.Areas.Admin.Models.AboutModel;
using BlogSite.Web.Areas.Admin.Models.AdminPanelModel;
using BlogSite.Web.Areas.Admin.Models.BlogModel;
using BlogSite.Web.Areas.Admin.Models.CategoryModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlogSite.Web
{
    public class WebModule : Module
    {
        private readonly string _connectionString;
        private readonly string _migrationAssemblyName;

        public WebModule(string connectionString, string migrationAssemblyName)
        {
            _connectionString = connectionString;
            _migrationAssemblyName = migrationAssemblyName;
        }

        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<APModel>();
            builder.RegisterType<BlogModel>();
            builder.RegisterType<CategoryModel>();
            builder.RegisterType<AboutModel>();
            base.Load(builder);
        }
    }
}

