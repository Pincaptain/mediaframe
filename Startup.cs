using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Mediaframe.Startup))]
namespace Mediaframe
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
