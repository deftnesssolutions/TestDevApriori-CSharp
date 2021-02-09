using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(OcamentoWeb.Startup))]
namespace OcamentoWeb
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
