using Autofac;
using BlogSite.Framework.AboutBS;
using BlogSite.Framework.AdminPanelBS;
using BlogSite.Framework.BlogBS;
using BlogSite.Framework.CategoryBS;
using BlogSite.Framework.CommentBS;
using Membership.Data;
using Membership.Services;

namespace BlogSite.Framework
{
    public class FrameworkModule : Module
    {
        private readonly string _connectionString;
        private readonly string _migrationAssemblyName;

        public FrameworkModule(string connectionString, string migrationAssemblyName)
        {
            _connectionString = connectionString;
            _migrationAssemblyName = migrationAssemblyName;
        }

        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<DatabaseContext>()
                .WithParameter("connectionString", _connectionString)
                .WithParameter("migrationAssemblyName", _migrationAssemblyName)
                .InstancePerLifetimeScope();

            builder.RegisterType<BlogUnitOfWork>().As<IBlogUnitOfWork>()
               .InstancePerLifetimeScope();

            builder.RegisterType<APService>().As<IAPService>()
               .InstancePerLifetimeScope();

            builder.RegisterType<CategoryRepository>().As<ICategoryRepository>()
               .InstancePerLifetimeScope();

            builder.RegisterType<CategoryService>().As<ICategoryService>()
               .InstancePerLifetimeScope();

            builder.RegisterType<BlogRepository>().As<IBlogRepository>()
               .InstancePerLifetimeScope();

            builder.RegisterType<BlogService>().As<IBlogService>()
               .InstancePerLifetimeScope();

            builder.RegisterType<AccountSeed>()
                .InstancePerLifetimeScope();

            builder.RegisterType<UserService>().As<IUserService>()
               .InstancePerLifetimeScope();

            builder.RegisterType<CurrentUserService>().As<ICurrentUserService>()
             .InstancePerLifetimeScope();

            builder.RegisterType<AboutRepository>().As<IAboutRepository>()
             .InstancePerLifetimeScope();

            builder.RegisterType<AboutService>().As<IAboutService>()
             .InstancePerLifetimeScope();

            builder.RegisterType<MainCommentRepository>().As<IMainCommentRepository>()
             .InstancePerLifetimeScope();

            builder.RegisterType<MainCommentService>().As<IMainCommentService>()
             .InstancePerLifetimeScope();

            base.Load(builder);
        }
    }
}
