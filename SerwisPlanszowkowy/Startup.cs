using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(SerwisPlanszowkowy.Startup))]
namespace SerwisPlanszowkowy
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
