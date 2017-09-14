using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(WebAppExercício.Startup))]
namespace WebAppExercício
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
