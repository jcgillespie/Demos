using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(AspNetTotp.Startup))]
namespace AspNetTotp
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
