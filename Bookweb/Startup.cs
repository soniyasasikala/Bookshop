using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Bookweb.Startup))]
namespace Bookweb
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
