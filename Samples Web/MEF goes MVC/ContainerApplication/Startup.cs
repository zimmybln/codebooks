using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(ContainerApplication.Startup))]
namespace ContainerApplication
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
