using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Merceria.Startup))]
namespace Merceria
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
