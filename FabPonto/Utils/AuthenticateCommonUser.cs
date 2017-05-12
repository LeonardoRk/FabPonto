using System;
using System.Data.Entity;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Web;
using System.Web.Mvc;
using System.Web.UI.WebControls;
using FabPonto.DAL;
using FabPonto.Models;

namespace FabPonto.Utils
{
    public class AuthenticateCommonUser : AuthenticateStrategy
    {
        public override bool Login(string nickName, string password)
        {
            SessionType = "common";
            bool result = false;
            password = Encryption.sha256_hash(password);


            result = IsAuthenticated(nickName, password);


            return result;
        }

        private bool IsAuthenticated(string nickName, string password)
        {
            bool result = false;
            IUser actualUser = null;

            try
            {
                using (var db = new FabContext())
                {
                    actualUser = db.Users.FirstOrDefault(u => u.NickName == nickName && u.Password == password);
                    if (actualUser != null)
                    {
                        CreateSession("User", nickName);
                        result = true;
                    }

                    actualUser = db.Admins.FirstOrDefault(u => u.NickName == nickName && u.Password == password);
                    if (actualUser != null)
                    {
                        CreateSession("Admin", nickName);
                        result = true;
                    }

                    return result;
                }
            }
            catch (Exception ex)
            {
                actualUser = null;
            }

            return result;
        }
    }
}