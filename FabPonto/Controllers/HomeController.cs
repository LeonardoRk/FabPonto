using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Ajax;
using FabPonto.DAL;
using FabPonto.Utils;

namespace FabPonto.Controllers
{
    public class HomeController : Controller
    {

        private FabContext db = new FabContext();

        public ActionResult Index()
        {
            return View();
        }


        public ActionResult About()
        {
//
//            var users = "";
//            foreach (var user in db.Users.ToList())
//            {
//                users = users + user.Name + " ";
//            }
//
//            ViewBag.Message = users;

            LdapConnection ldapConnection = new LdapConnection();
            ViewBag.Message = ldapConnection.SearchAllUsers();

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}