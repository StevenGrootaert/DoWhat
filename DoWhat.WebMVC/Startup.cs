using Autofac;
using Autofac.Integration.Mvc;
using DoWhat.Contracts;
using DoWhat.Services;
using Microsoft.Owin;
using Owin;
using System.Web.Mvc;

[assembly: OwinStartupAttribute(typeof(DoWhat.WebMVC.Startup))]
namespace DoWhat.WebMVC
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            //// ------------ this is for the Autofac dependancy injection

            var builder = new ContainerBuilder();

            builder.RegisterControllers(typeof(MvcApplication).Assembly);
            // OPTIONAL: Register web abstractions like HttpContextBase.
            builder.RegisterModule<AutofacWebTypesModule>();

            //builder.RegisterType<ThingService>().As<IThingService>();
            builder.RegisterType<CatagoryService>().As<ICatagoryService>();
            //builder.RegisterType<ResourceService>().As<IResourceService>();


            //// Set the dependency resolver to be Autofac.
            var container = builder.Build();
            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));

            // -------------

            ConfigureAuth(app);
        }
    }
}
