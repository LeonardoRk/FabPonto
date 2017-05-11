using System;
using System.Linq;
using System.Web.Mvc;
using System.Web.UI.WebControls;
using FabPonto.DAL;
using FabPonto.Models;
using Newtonsoft.Json;

namespace FabPonto.Controllers
{
    [AllowAnonymous]
    public class WorktimeRegisterController : Controller
    {
        public ActionResult Index()
        {
            return Content("");
        }

        private string GetCurrentTime()
        {
            String currentTime = DateTime.Now.ToString("h:mm:ss tt");
            return currentTime;
        }

        [System.Web.Http.HttpGet]
        public string SaveUserWorkTime()
        {

            String currentTime = GetCurrentTime();
            String userState = null;

            IUser currentUser = null;

            using (var db = new FabContext())
            {
                currentUser = db.Users.First();

            }

            if (currentUser != null)
            {
                currentUser.ChangeWorkingState();

                //save current time on database

                userState = currentUser.WorkingState.GetType().ToString();
            }

            return userState;
        }


    }
}