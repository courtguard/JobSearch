using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(JobSearch.Startup))]
namespace JobSearch
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
