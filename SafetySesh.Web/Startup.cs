using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(SafetySesh.Web.Startup))]
namespace SafetySesh.Web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
