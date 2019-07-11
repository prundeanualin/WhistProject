using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(WhistProject.Startup))]
namespace WhistProject
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
