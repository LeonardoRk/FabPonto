using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using FabPonto.Models;
using FabPonto.DAL;

namespace FabPonto.Controllers
{
    public class UserController : Controller
    {
        private readonly FabContext _db = FabContext.GetFabContextInstance();

        public ActionResult Index()
        {
            List<User> userList = _db.Users.ToList();
            return View(userList);
        }

        // GET
        public ActionResult Register()
        {
            User user = new User();
            return View(user);
        }

        [HttpPost]
        public ActionResult Register(User user)
        {
            _db.Users.Add(user);
            _db.SaveChanges();

            return RedirectToAction("Index", "Home");
        }
    }
}