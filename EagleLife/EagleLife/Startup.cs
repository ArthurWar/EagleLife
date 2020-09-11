using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(EagleLife.Startup))]
namespace EagleLife
{
    public partial class Startup {
        public void Configuration(IAppBuilder app) {
            ConfigureAuth(app);
        }
    }
}
