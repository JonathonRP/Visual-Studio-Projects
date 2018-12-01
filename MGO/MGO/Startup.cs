using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(MGO.Startup))]
namespace MGO
{
    public partial class Startup {
        public void Configuration(IAppBuilder app) {
            ConfigureAuth(app);
        }
    }
}
