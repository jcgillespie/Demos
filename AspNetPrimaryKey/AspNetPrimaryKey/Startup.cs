using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(AspNetPrimaryKey.Startup))]
namespace AspNetPrimaryKey
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
