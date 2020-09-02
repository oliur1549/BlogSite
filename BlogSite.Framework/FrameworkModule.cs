using Autofac;
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


            builder.RegisterType<AccountSeed>()
                .InstancePerLifetimeScope();

            builder.RegisterType<UserService>().As<IUserService>()
               .InstancePerLifetimeScope();

            builder.RegisterType<CurrentUserService>().As<ICurrentUserService>()
             .InstancePerLifetimeScope();
            base.Load(builder);
        }
    }
}
