using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(GalleriaDesign.Startup))]
namespace GalleriaDesign
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
