using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(NUOVO.Startup))]
namespace NUOVO
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
