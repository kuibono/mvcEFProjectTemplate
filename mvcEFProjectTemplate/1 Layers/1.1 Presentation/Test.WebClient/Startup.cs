using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Test.WebClient.Startup))]
namespace Test.WebClient
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
