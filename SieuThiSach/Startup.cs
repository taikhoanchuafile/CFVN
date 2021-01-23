using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(SieuThiSach.Startup))]
namespace SieuThiSach
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
