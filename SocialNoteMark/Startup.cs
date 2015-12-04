using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(SocialNoteMark.Startup))]
namespace SocialNoteMark
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
