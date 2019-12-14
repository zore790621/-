using System.Reflection;
using System.Web.Http;
using System.Web.Mvc;
using Autofac;
using Autofac.Integration.Mvc;
using Autofac.Integration.WebApi;
using DotrA_Lab.IOC.AutofacModule;

namespace DotrA.App_Start
{
    public class AutofacConfig
    {
        public static void ConfigureContainer(HttpConfiguration config)
        {
            var builder = new ContainerBuilder();

            builder.RegisterApiControllers(Assembly.GetExecutingAssembly());
            builder.RegisterWebApiFilterProvider(config);

            builder.RegisterControllers(typeof(WebApiApplication).Assembly);

            builder.RegisterFilterProvider();

            builder.RegisterModule(new DataServiceModule());
            builder.RegisterModule(new OrmModule());

            builder.RegisterHttpRequestMessage(config);

            var container = builder.Build();

            config.DependencyResolver = new AutofacWebApiDependencyResolver(container);

            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));
        }
    }
}