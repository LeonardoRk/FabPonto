using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using System.Web.Http;

namespace FabPonto
{
    public class Global : HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            GlobalConfiguration.Configure(WebApiConfig.Register);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            DataTables.AspNet.Mvc5.Configuration.RegisterDataTables();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
        }
    }
}