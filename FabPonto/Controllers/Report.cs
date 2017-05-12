using System.Web.Mvc;

namespace FabPonto.Controllers
{
    public abstract class Report
    {
        public abstract void generateReport();
    }
}