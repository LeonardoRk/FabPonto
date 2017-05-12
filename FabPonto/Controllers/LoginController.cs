using System;
using System.DirectoryServices;
using System.Linq;
using System.Web.Mvc;
using FabPonto.DAL;
using FabPonto.Models;
using FabPonto.Utils;

namespace FabPonto.Controllers
{
    [AllowAnonymous]
    public class LoginController : Controller
    {
        private readonly FabContext _db = new FabContext();
        public static IUser User;

        public ActionResult Index()
        {
            return View("_Login");
        }
        [HttpPost]
        public ActionResult CommonLogin()
        {
            AuthenticateContext context = new AuthenticateContext(new AuthenticateCommonUser());

            string nomeUsuario;
            string senhaUsuario;
            try
            {
                nomeUsuario = Request.Form["nomeUsuario"];
                senhaUsuario = Request.Form["senhaUsuario"];
            }
            catch (NullReferenceException)
            {
                nomeUsuario = null;
                senhaUsuario = null;
            }


            if (context.Login(nomeUsuario,  senhaUsuario))
            {
                using (var db = new FabContext())
                {
                    User = db.Users.FirstOrDefault(a => a.NickName == nomeUsuario);
                }
                return RedirectToAction("Index", "Home");
            }
            else
            {
                ModelState.AddModelError("", "Login não efetuado. Favor verificar o login e a senha e tentar novamente.");
                return RedirectToAction("Index");
            }
        }

        public ActionResult LogOff()
        {
            AuthenticateContext context = new AuthenticateContext(new AuthenticateCommonUser());

            context.Logout();

            return RedirectToAction("Index", "Home");
        }

    }
}