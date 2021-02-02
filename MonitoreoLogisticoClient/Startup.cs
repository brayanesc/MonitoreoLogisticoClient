using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(MonitoreoLogisticoClient.Startup))]
namespace MonitoreoLogisticoClient
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            Helpers.ConnectionHelper.InitializeClient();
            ConfigureAuth(app);
        }
    }
}
