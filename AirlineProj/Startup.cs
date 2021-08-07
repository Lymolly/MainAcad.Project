using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(AirlineProj.Startup))]
namespace AirlineProj
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
