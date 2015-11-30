using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(TDMT_DOAN.Startup))]
namespace TDMT_DOAN
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
