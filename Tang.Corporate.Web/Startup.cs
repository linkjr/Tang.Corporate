using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Tang.Corporate.Web.Startup))]
namespace Tang.Corporate.Web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
