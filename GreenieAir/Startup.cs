using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(GreenieAir.Startup))]
namespace GreenieAir
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
