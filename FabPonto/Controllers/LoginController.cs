using System;
using System.DirectoryServices;
using System.Web.Mvc;

namespace FabPonto.Controllers
{
    [AllowAnonymous]
    public class LoginController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login()
        {
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

            if (IsAuthenticated("LDAP://192.168.151.194", nomeUsuario, senhaUsuario))
            {
                Session["NomeUsuario"] = nomeUsuario;

                return RedirectToAction("Index", "Home");
            }
            else
            {
                ModelState.AddModelError("", "Login não efetuado. Favor verificar o login e a senha e tentar novamente.");
            }

            return RedirectToAction("Index");
        }

        public bool IsAuthenticated(string srvr, string usr, string pwd)
        {
            bool authenticated = false;

            try
            {
//                DirectoryEntry entry = new DirectoryEntry(srvr, usr, pwd);
//                object nativeObject = entry.NativeObject;
                authenticated = true;
            }
            catch (DirectoryServicesCOMException cex)
            {
                //Não autenticado; A razão é cex
                System.Diagnostics.Debug.WriteLine(cex.Message);

            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(ex.Message);
                //Não autenticado; razão é ex ( é opicional o uso dessa)
            }

            return authenticated;
        }

        public ActionResult LogOff()
        {
            Session["NomeUsuario"] = null;

            return RedirectToAction("Index", "Home");
        }

    }
}