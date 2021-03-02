using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(GeekHub.Web.Startup))]
namespace GeekHub.Web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
