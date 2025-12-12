using Microsoft.Owin;
using Owin;
[assembly: OwinStartupAttribute(typeof(PinePawRetreat.Startup))]
namespace PinePawRetreat
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
