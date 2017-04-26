using System;
using System.Linq;
using System.Web.Mvc;
using FabPonto.DAL;
using MySql.Data.MySqlClient;

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

        public ActionResult Hours()
        {


            MySqlConnection connection = new MySqlConnection("Database=FabContext;Data Source=localhost;User " +
                                                             "Id=root;Password=root");
            connection.Open();

            MySqlCommand command =  connection.CreateCommand();
            command.CommandText = "select * from hours";
            MySqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                string a = reader.GetString(0);
                string b = reader["id"].ToString();
                ViewBag.Message = a;
            }
            reader.Close();

            return View();
        }



    }
}