using System.Configuration;
using Owin;
using Microsoft.Owin;
using Microsoft.Owin.Security.Cookies;

namespace FabPonto
{
    public class Sartup
    {
        public void Configuration(IAppBuilder app)
        {
            app.UseCookieAuthentication(new CookieAuthenticationOptions
            {
                AuthenticationType = "ApplicationCookie",
                LoginPath = new PathString("/auth/login")
            });
        }
    }
}