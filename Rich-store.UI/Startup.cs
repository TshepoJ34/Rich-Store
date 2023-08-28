using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Rich_store.UI.Startup))]
namespace Rich_store.UI
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
