using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(BP_final.Startup))]
namespace BP_final
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
