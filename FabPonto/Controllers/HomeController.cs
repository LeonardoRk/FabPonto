using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Ajax;
using FabPonto.DAL;

namespace FabPonto.Controllers
{
    [AllowAnonymous]
    public class HomeController : Controller
    {

        private FabContext db = new FabContext();

        public ActionResult Index()
        {
            return View();
        }


        public ActionResult About()
        {

            var users = "";
            foreach (var user in db.Users.ToList())
            {
                users = users + user.Name + " ";
            }

            ViewBag.Message = users;
            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}