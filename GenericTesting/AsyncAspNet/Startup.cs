using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(AsyncAspNet.Startup))]
namespace AsyncAspNet
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
