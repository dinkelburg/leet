using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Leet.Kantilever.FEWebwinkel.Site.Startup))]
namespace Leet.Kantilever.FEWebwinkel.Site
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
