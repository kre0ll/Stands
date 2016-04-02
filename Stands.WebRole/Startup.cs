using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Stands.WebRole.Startup))]
namespace Stands.WebRole
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
