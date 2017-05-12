using System;
using System.Web;
using System.Web.Mvc;
using FabPonto.Models;

namespace FabPonto.Utils
{
    public abstract class AuthenticateStrategy
    {
        public const string SessionUserName = "UserName";
        public const string SessionUserType = "UserType";
        public const string SessionLoginType = "LoginType";

        public string SessionType;

        public void CreateSession(string userType,string nickName)
        {
            HttpContext.Current.Session[SessionUserName] = nickName;
            HttpContext.Current.Session[SessionLoginType] = SessionType;
            HttpContext.Current.Session[SessionUserType] = userType;
        }

        public abstract bool Login(string nickName, string password );

        public void Logout()
        {
            HttpContext.Current.Session[SessionUserName] = null;
            HttpContext.Current.Session[SessionUserType] = null;
            HttpContext.Current.Session[SessionLoginType] = null;
        }
    }
}