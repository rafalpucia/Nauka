using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Nauka.Startup))]
namespace Nauka
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
