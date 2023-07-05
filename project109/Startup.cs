using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(project109.Startup))]
namespace project109
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
           // ConfigureAuth(app);
        }
    }
}
