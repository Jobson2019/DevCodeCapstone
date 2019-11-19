using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Pubcrew.Startup))]
namespace Pubcrew
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
