using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(SmartTalo.Startup))]
namespace SmartTalo
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
