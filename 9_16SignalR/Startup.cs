using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(_9_16SignalR.Startup))]
namespace _9_16SignalR
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);

            app.MapSignalR();

        }
    }
}
