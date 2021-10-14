using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(HeroAndVillains.WebMVC.Startup))]
namespace HeroAndVillains.WebMVC
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
