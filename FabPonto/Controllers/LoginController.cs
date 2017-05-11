using System;
using System.DirectoryServices;
using System.Linq;
using System.Web.Mvc;
using FabPonto.DAL;
using FabPonto.Models;
using FabPonto.Utils;

namespace FabPonto.Controllers
{
    public class LoginController : Controller
    {
        private readonly FabContext _db = FabContext.GetFabContextInstance();

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


            if ( IsAuthenticated(nomeUsuario,  Encryption.sha256_hash(senhaUsuario)))
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

        private bool IsAuthenticated(string nomeUsuario, string senhaUsuario)
        {
            bool result = false;
            User actualUser;

            try
            {
                actualUser = _db.Users.FirstOrDefault(user => user.NickName == nomeUsuario && user.Password == senhaUsuario);
            }
            catch (Exception ex)
            {
                actualUser = null;
            }

            if (actualUser != null)
            {
                result = true;
            }


            return result;
        }

        public bool IsLdapAuthenticated(string srvr, string usr, string pwd)
        {
            bool authenticated = false;

            try
            {
//                DirectoryEntry entry = new DirectoryEntry(srvr, usr, pwd);
//                object nativeObject = entry.NativeObject;
//                authenticated = true;
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