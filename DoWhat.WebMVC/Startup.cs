using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(DoWhat.WebMVC.Startup))]
namespace DoWhat.WebMVC
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
